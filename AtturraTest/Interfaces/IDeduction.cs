﻿using AtturraTest.Enums;

namespace AtturraTest.Interfaces
{
    public interface IDeduction : IEntity
    {
        public string Name { get; }
        public DeductionType DeductionType { get; }
        public bool IsDecimalPlacesSignificant { get; }

        public decimal Calculate(decimal grossPackage);

    }
}