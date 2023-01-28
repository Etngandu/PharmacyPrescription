﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ENB.PharmaciesAndPrescriptions.Entities.Collections
{
  /// <summary>
  /// Represents a collection of People instances in the system.
  /// </summary>
  public class Customers : CollectionBase<Customer>
  {
        /// <summary>
        /// Initializes a new instance of the <see cref="Operators"/> class.
        /// </summary>
        public Customers() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operators"/> class.
        /// </summary>
        /// <param name="initialList">Accepts an IList of Person as the initial list.</param>
        public Customers(IList<Customer> initialList) : base(initialList) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operators"/> class.
        /// </summary>
        /// <param name="initialList">Accepts a CollectionBase of Person as the initial list.</param>
        public Customers(CollectionBase<Customer> initialList) : base(initialList) { }

    /// <summary>
    /// Validates the current collection by validating each individual item in the collection.
    /// </summary>
    /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
    public IEnumerable<ValidationResult> Validate()
    {
      var errors = new List<ValidationResult>();
      foreach (var customer in this)
      {
        errors.AddRange(customer.Validate());
      }
      return errors;
    }
  }
}
