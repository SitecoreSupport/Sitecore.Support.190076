﻿using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Pipelines.Search;
using Sitecore.Search;
using System;

namespace Sitecore.Support.Pipelines.Search
{
    /// <summary>
    /// Resolves id searches.
    /// </summary>
    public class IDResolver
    {
        /// <summary>
        /// Runs the processor.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void Process(SearchArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (!ID.IsID(args.TextQuery) || string.IsNullOrEmpty(args.TextQuery))
            {
                return;
            }
            Item item = args.Database.GetItem(args.TextQuery);
            if (item != null)
            {
                SearchResult result = SearchResult.FromItem(item);
                args.Result.AddResultToCategory(result, Translate.Text("Direct Hit"));
            }
        }
    }
}