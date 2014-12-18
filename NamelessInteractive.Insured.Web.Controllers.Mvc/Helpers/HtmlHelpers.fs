namespace NamelessInteractive.Insured.Web.Controllers.Mvc

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
        let providers = ModelValidatorProviders.Providers.GetValidators(metaData,this.ViewContext) |> Seq.map(fun a -> a.GetClientValidationRules())
        ()

    static member private NgTextBox(this: HtmlHelper<'TModel>,name,metaData, template) =
        let fullHtmlFieldName = this.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name)
        let tagBuilder = new TagBuilder("input")
        tagBuilder.MergeAttribute("type", "text")
        tagBuilder.MergeAttribute("name", fullHtmlFieldName,true)
        tagBuilder.GenerateId(fullHtmlFieldName)
        //tagBuilder.MergeAttributes(HtmlHelpers.ValidationAttributes(name,metaData))
        tagBuilder.MergeAttribute("ng-model", template)
        MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing))
        
        

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