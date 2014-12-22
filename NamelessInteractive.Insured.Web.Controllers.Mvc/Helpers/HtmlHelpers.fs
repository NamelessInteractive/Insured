﻿namespace NamelessInteractive.Insured.Web.Controllers.Mvc

open System.Web.Mvc
open System.Web
open System.Runtime.CompilerServices
open System.Web.Mvc.Html

[<Extension>]
type HtmlHelpers() =
    [<Extension>]
    static member NamedValue<'TModel, 'TValue> (this : HtmlHelper<'TModel>, expression: System.Linq.Expressions.Expression<System.Func<'TModel, 'TValue>>) =
        let name = this.DisplayNameFor(expression).ToString()
        let value = this.ValueFor(expression).ToString()
        let htmlString = 
            sprintf 
                """<div class="col-lg-6">
                   <div class="col-lg-4"><label>%s</label></div>
                   <div class="col-lg-8">%s</div>
                   </div>""" name value
        HtmlString(htmlString)
        
    [<Extension>]
    static member NamedValue<'TModel, 'TValue> (this : HtmlHelper<'TModel>, expression: System.Linq.Expressions.Expression<System.Func<'TModel, 'TValue>>, template) =
        let name = this.DisplayNameFor(expression).ToString()
        let htmlString = 
            sprintf 
                """<div class="col-lg-6">
                   <div class="col-lg-4"><label>%s</label></div>
                   <div class="col-lg-8">%s</div>
                   </div>""" name template
        HtmlString(htmlString)

    static member private ValidationAttributes(this:HtmlHelper<'TModel>,name, metaData:ModelMetadata) =
        let rules = ModelValidatorProviders.Providers.GetValidators(metaData,this.ViewContext) |> Seq.map(fun a -> a.GetClientValidationRules()) |> Seq.collect(fun p -> p)
        let res = System.Collections.Generic.Dictionary<string,string>()
        rules |> Seq.iter(fun r -> res.Add(r.ValidationType,r.ValidationType))
        res

    static member private NgTextBox(this: HtmlHelper<'TModel>,name,metaData, template) =
        let fullHtmlFieldName = this.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name)
        let tagBuilder = new TagBuilder("input")
        tagBuilder.MergeAttribute("type", "text")
        tagBuilder.MergeAttribute("name", fullHtmlFieldName,true)
        tagBuilder.AddCssClass("form-control")
        tagBuilder.GenerateId(fullHtmlFieldName)
        let test= HtmlHelpers.ValidationAttributes(this,name,metaData)
        tagBuilder.MergeAttributes(HtmlHelpers.ValidationAttributes(this,name,metaData))
        tagBuilder.MergeAttribute("ng-model", template)
        MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing))

    static member private NgCheckbox(this: HtmlHelper<'TModel>,name,metaData, template) =
        let fullHtmlFieldName = this.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name)
        let tagBuilder = new TagBuilder("input")
        tagBuilder.MergeAttribute("type", "checkbox")
        tagBuilder.MergeAttribute("name", fullHtmlFieldName,true)
        tagBuilder.MergeAttribute("ng-click",sprintf "%s=!%s" template template)
        tagBuilder.MergeAttribute("ng-checked", sprintf "%s==true" template)
        tagBuilder.AddCssClass("form-control")
        tagBuilder.GenerateId(fullHtmlFieldName)
        let test= HtmlHelpers.ValidationAttributes(this,name,metaData)
        tagBuilder.MergeAttributes(HtmlHelpers.ValidationAttributes(this,name,metaData))
        MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing))

    static member private NgDropdown(this: HtmlHelper<'TModel>,name,metaData, template, options) =
        let fullHtmlFieldName = this.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name)
        let tagBuilder = new TagBuilder("select")
        tagBuilder.MergeAttribute("name", fullHtmlFieldName,true)
        tagBuilder.MergeAttribute("ng-model",template)
        if not (System.String.IsNullOrEmpty(options)) then
            tagBuilder.MergeAttribute("ng-options",options)
        tagBuilder.AddCssClass("form-control")
        tagBuilder.GenerateId(fullHtmlFieldName)
        tagBuilder.InnerHtml <- "<option value=\"\">... Please Select ...</option>"
        let test= HtmlHelpers.ValidationAttributes(this,name,metaData)
        tagBuilder.MergeAttributes(HtmlHelpers.ValidationAttributes(this,name,metaData))
        MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal))
        
        
        

    [<Extension>]
    static member LabelledTextBox<'TModel, 'TValue> (this : HtmlHelper<'TModel>, expression: System.Linq.Expressions.Expression<System.Func<'TModel, 'TValue>>, template) =
        let metadata = ModelMetadata.FromLambdaExpression(expression,this.ViewData)
        let fieldName = ExpressionHelper.GetExpressionText(expression)
        let name = this.DisplayNameFor(expression).ToString()
        let id = this.IdFor(expression).ToString()
        let textBox = HtmlHelpers.NgTextBox(this,fieldName,metadata, template).ToHtmlString()
        let htmlString = 
            sprintf 
                """<div class="col-lg-6">
                   <div class="col-lg-4"><label for="%s">%s</label></div>
                   <div class="col-lg-8">%s</div>
                   </div>""" id name textBox
        HtmlString(htmlString)

    [<Extension>]
    static member LabelledCheckbox<'TModel, 'TValue> (this : HtmlHelper<'TModel>, expression: System.Linq.Expressions.Expression<System.Func<'TModel, 'TValue>>, template) =
        let metadata = ModelMetadata.FromLambdaExpression(expression,this.ViewData)
        let fieldName = ExpressionHelper.GetExpressionText(expression)
        let name = this.DisplayNameFor(expression).ToString()
        let id = this.IdFor(expression).ToString()
        let checkBox = HtmlHelpers.NgCheckbox(this,fieldName,metadata, template).ToHtmlString()
        let htmlString = 
            sprintf 
                """<div class="col-lg-6">
                   <div class="col-lg-4"><label for="%s">%s</label></div>
                   <div class="col-lg-8">%s</div>
                   </div>""" id name checkBox
        HtmlString(htmlString)

    [<Extension>]
    static member LabelledDropdown<'TModel, 'TValue> (this : HtmlHelper<'TModel>, expression: System.Linq.Expressions.Expression<System.Func<'TModel, 'TValue>>, template, options) =
        let metadata = ModelMetadata.FromLambdaExpression(expression,this.ViewData)
        let fieldName = ExpressionHelper.GetExpressionText(expression)
        let name = this.DisplayNameFor(expression).ToString()
        let id = this.IdFor(expression).ToString()
        let dropDown = HtmlHelpers.NgDropdown(this,fieldName,metadata, template,options).ToHtmlString()
        let htmlString = 
            sprintf 
                """<div class="col-lg-6">
                   <div class="col-lg-4"><label for="%s">%s</label></div>
                   <div class="col-lg-8">%s</div>
                   </div>""" id name dropDown
        HtmlString(htmlString)