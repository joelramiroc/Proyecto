// <copyright file="Providers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Models
{
    using System;

    public class ApplicationUser //: IdentityUser, IConcurrencyChecked
    {
        public Guid ConcurrencyToken { get; set; }
    }
}