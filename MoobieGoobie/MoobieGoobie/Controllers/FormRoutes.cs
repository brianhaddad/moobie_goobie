using Microsoft.AspNetCore.Mvc;
using Moobie.WebView.DTOs;
using Moobie.WebView.Extensions;
using Moobie.WebView.TemplateModels;
using System.Collections.Generic;

namespace MoobieGoobie.Controllers
{
    [ApiController]
    [Route("/routes")]
    public class FormRoutes : ControllerBase
    {
        public PagePayload<IndexData> Index()
        {
            //TEMPORARY
            //TODO: actual view builder to translate data into template view
            var data = new IndexData
            {
                UserText = new Dictionary<string, string>
                {
                    { "title", "Title Test" },
                    { "submitButton", "Send It" },
                    { "defaultValue", "Did this extract?" },
                },
                OptionCollections = new Dictionary<string, List<Option>>
                {
                    {
                        "selectExample",
                        new List<Option>
                        {
                            new Option { Display = "Noncommittal Selection", Value = "unknown_selection" },
                            new Option { Display = "True Selection", Value = "true_selection" },
                            new Option { Display = "False Selection", Value = "false_selection" },
                        }
                    },
                    {
                        "checkboxExample",
                        new List<Option>
                        {
                            new Option { Display = "Pickles", Value = "pickles" },
                            new Option { Display = "Lettuce", Value = "lettuce" },
                            new Option { Display = "Tomatoes", Value = "tomatoes" },
                            new Option { Display = "Onions", Value = "onions" },
                        }
                    },
                    {
                        "radioExample",
                        new List<Option>
                        {
                            new Option { Display = "First Option", Value = "first_option" },
                            new Option { Display = "Second Option", Value = "second_option" },
                        }
                    },
                },
            };
            var result = new PagePayload<IndexData>
            {
                PageTitle = "Test Page",
                Data = data,
            };
            result
                .AddTemplate("div", new Dictionary<string, string>
                {
                    { "style", "width: 400px; margin: 0px auto;" },
                })
                .AddChild("fieldset", childConfig: (fieldset) =>
                {
                    fieldset
                        .AddChild("legend", innerHTML: "data.userText.title")
                        .AddChild("form", new Dictionary<string, string>
                        {
                            { "id", "formTest" },
                            { "style", "display: flex; flex-direction: column;" }
                        }, childConfig: (form) =>
                        {
                            form.AddChild("input", new Dictionary<string, string>
                            {
                                { "type", "text" },
                                { "name", "nameField" },
                                { "placeholder", "data.userText.defaultValue" },
                            })
                            .AddChild("div", childConfig: (dropdownDiv) =>
                            {
                                dropdownDiv.AddChild("label", new Dictionary<string, string>
                                {
                                    { "for", "dropdownSelection" },
                                }, "Pick One: ")
                                .AddChild("select", new Dictionary<string, string>
                                {
                                    { "name", "dropdownSelection" },
                                }, childConfig: (dropdown) =>
                                {
                                    dropdown.ChildrenDataSource = "data.optionCollections.selectExample";
                                    dropdown.ChildTemplate = new TemplateNode
                                    {
                                        Type = "option",
                                        Attributes = new Dictionary<string, string> { { "value", "data.value" } },
                                        InnerHTML = "data.display",
                                    };
                                });
                            })
                            .AddChild("div", childConfig: (checkboxDiv) =>
                            {
                                checkboxDiv.ChildrenDataSource = "data.optionCollections.checkboxExample";
                                checkboxDiv.ChildTemplate = new TemplateNode
                                {
                                    Type = "div",
                                }.AddChild("input", new Dictionary<string, string>
                                {
                                    { "type", "checkbox" },
                                    { "name", "checkboxes" },
                                    { "value", "data.value" },
                                })
                                .AddChild("label", new Dictionary<string, string> { { "for", "data.value" } }, "data.display");
                            })
                            .AddChild("textarea", new Dictionary<string, string> { { "name", "paragraph" } })
                            .AddChild("div", childConfig: (radioDiv) =>
                            {
                                radioDiv.ChildrenDataSource = "data.optionCollections.radioExample";
                                radioDiv.ChildTemplate = new TemplateNode
                                {
                                    Type = "div",
                                }.AddChild("input", new Dictionary<string, string>
                                {
                                    { "type", "radio" },
                                    { "name", "radioSelection" },
                                    { "value", "data.value" },
                                })
                                .AddChild("label", new Dictionary<string, string> { { "for", "data.value" } }, "data.display");
                            })
                            .AddChild("button", new Dictionary<string, string> { { "type", "submit" } }, "data.userText.submitButton");
                        });
                });
            return result;
        }
    }
}
