﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Helpers.ViewModels.Fields;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Model.ContentLinks;

namespace Telerik.Sitefinity.Frontend.Mvc.Helpers
{
    /// <summary>
    /// This class contains helper methods for rendering of the fields.
    /// </summary>
    public static class FieldHelpers
    {
        /// <summary>
        /// Renders longs the text area field.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="dynamicFieldItem">The dynamic field item.</param>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString LongTextAreaField(this HtmlHelper helper, string text, string fieldName, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new TextFieldViewModel(text, fieldName);

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.TextAreaFieldViewName, model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString LongRichTextField(this HtmlHelper helper, string text, string fieldName, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new TextFieldViewModel(text, fieldName);

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.RichTextFieldViewName, model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString ShortTextField(this HtmlHelper helper, string text, string fieldName, string fieldTitle, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new TextFieldViewModel(text, fieldName, fieldTitle);

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.ShortTextFieldViewName, model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString DateField(this HtmlHelper helper, DateTime date, string dateFormat, string fieldName, string fieldTitle, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new DateFieldViewModel(date, dateFormat, fieldName, fieldTitle);

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.DateFieldViewName, model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString NumberField(this HtmlHelper helper, string text, string unit, string fieldName, string fieldTitle, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new TextFieldViewModel(text, fieldName, fieldTitle);
            model.Unit = unit;

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.NumberFieldViewName, model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString PriceField(this HtmlHelper helper, string text, string fieldName, string format, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new TextFieldViewModel(text, fieldName);
            model.Format = format;

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.PriceFieldViewName, model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString YesNoField(this HtmlHelper helper, bool fieldValue, string fieldName, string fieldTitle, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new ChoiceFieldViewModel(fieldValue, fieldName, fieldTitle);

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.YesNoFieldViewName, model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString ChoiceField(this HtmlHelper helper, string fieldValue, string fieldName, string fieldTitle, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new ChoiceFieldViewModel(fieldValue, fieldName, fieldTitle);

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.SingleChoiceFieldViewName, model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString ChoiceField(this HtmlHelper helper, IEnumerable fieldValues, string fieldName, string fieldTitle, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new ChoiceFieldViewModel(fieldValues, fieldName, fieldTitle);

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.MultiChoiceFieldViewName, model);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "fieldName"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "fieldTitle"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "fieldValue"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString ImageField(this HtmlHelper helper, ContentLink fieldValue, string fieldName, string fieldTitle, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;
            var model = new MediaFieldViewModel(fieldValue, fieldName, fieldTitle);

            return ASP.PartialExtensions.Partial(helper, FieldHelpers.ImageFieldViewName, model);
        }

        /// <summary>
        /// Renders taxonomy field.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="dynamicFieldItem">The dynamic field item.</param>
        /// <param name="classificationId">The classification identifier.</param>
        /// <param name="fieldTitle">The field title.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static System.Web.Mvc.MvcHtmlString TaxonomyField(this HtmlHelper helper, object classificationFieldValue, Guid classificationId, string fieldTitle, string fieldName, string cssClass = "")
        {
            helper.ViewBag.CssClass = cssClass;

            var model = new ClassificationFieldViewModel((IList<Guid>)classificationFieldValue, classificationId, fieldTitle, fieldName);

            if (model.GetTaxonomyType() == Telerik.Sitefinity.Taxonomies.Model.TaxonomyType.Flat)
                return ASP.PartialExtensions.Partial(helper, FieldHelpers.FlatTaxonomyFieldViewName, model);
            else if (model.GetTaxonomyType() == Telerik.Sitefinity.Taxonomies.Model.TaxonomyType.Hierarchical)
                return ASP.PartialExtensions.Partial(helper, FieldHelpers.HierarchicalTaxonomyFieldViewName, model);

            return null;
        }

        private const string TextAreaFieldViewName = "LongTextAreaField";
        private const string RichTextFieldViewName = "LongRichTextField";
        private const string ShortTextFieldViewName = "ShortTextField";
        private const string NumberFieldViewName = "NumberField";
        private const string PriceFieldViewName = "PriceField";
        private const string DateFieldViewName = "DateField";
        private const string YesNoFieldViewName = "YesNoField";
        private const string SingleChoiceFieldViewName = "SingleChoiceField";
        private const string MultiChoiceFieldViewName = "MultiChoiceField";
        private const string FlatTaxonomyFieldViewName = "FlatTaxonomyField";
        private const string HierarchicalTaxonomyFieldViewName = "HierarchicalTaxonomyField";
        private const string ImageFieldViewName = "ImageField";
    }
}
