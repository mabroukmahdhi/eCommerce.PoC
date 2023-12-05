// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SaarWorld.Models.Products;

namespace SaarWorld.Models.Companies
{
    public class Company
    {
        private const string logoPlaceholder = "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";
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public string Logo { get; set; }
        public string LogoUrl => $"data:image/jpeg;base64,{(string.IsNullOrWhiteSpace(Logo) ? logoPlaceholder : Logo)}";
        public ICollection<Product> Products { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedByUserId { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

    }
}