using System;
using System.Collections.Generic;
using System.Text;

namespace WikiBookGetApi.Core.SearchModels
{
    public class SearchParameterModel : Attribute
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
    }
}
