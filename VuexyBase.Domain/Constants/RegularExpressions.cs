namespace VuexyBase.Domain.Constants
{
    public static class RegularExpressions
    {
        // User & Identification
        public static readonly string UserNameRegex = @"^[a-zA-Z0-9_]{3,20}$";
        // ✅ Valid: "User_123" | ❌ Invalid: "user@123" (Special characters not allowed)

        public static readonly string SaudiNationalId = @"^[12]\d{9}$";
        // ✅ Valid: "1023456789" (Saudi ID starts with 1 or 2, followed by 9 digits)



        // Financial
        public static readonly string Iban = @"^SA\d{2}[0-9]{20}$";
        // ✅ Valid: "SA3512345678901234567890"

        public static readonly string BankAccountNo = @"^\d{18}$";
        // ✅ Valid: "123456789012345678" (Exactly 18 digits)

        public static readonly string CommercialNumber = @"^\d{10}$";
        // ✅ Valid: "1234567890" (Exactly 10 digits)



        // Contact Information
        public static readonly string Email = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        // ✅ Valid: "test@example.com" | ❌ Invalid: "test@.com" (Missing domain name)

        public static readonly string SaudiPhone = @"^((\+966|0)5[013469178]\d{7})$";
        // ✅ Valid: "+966501234567", "0551234567" | ❌ Invalid: "1234567890" (Invalid format)



        // Numeric Patterns
        public static readonly string PositiveIntegers = @"^[1-9][0-9]*$";
        // ✅ Valid: "123" | ❌ Invalid: "0" (Zero is not allowed)

        public static readonly string PositiveFloating = @"^[1-9][0-9]*\.?[0-9]{0,2}$";
        // ✅ Valid: "12.34", "5" | ❌ Invalid: "-3.4" (Negative numbers not allowed)

        public static readonly string Decimals = @"^(0|[1-9]\d*)(\.\d+)?$";
        // ✅ Valid: "0.5", "10.2", "100" | ❌ Invalid: "-10.5" (Negative not allowed)

        public static readonly string Percentage = @"^(?:[1-9][0-9]?(?:\.\d{1,2})?|0?\.\d{1,2}|100)$";
        // ✅ Valid: "99.99", "50", "0.5" | ❌ Invalid: "150" (Over 100%)



        // URL & Web
        public static readonly string Link = @"^(https?:\/\/)?(www\.)?[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\/?$";
        // ✅ Valid: "https://example.com" | ❌ Invalid: "htp://example" (Invalid scheme)

        public static readonly string Slug = @"^[a-z0-9]+(?:-[a-z0-9]+)*$";
        // ✅ Valid: "product-name" | ❌ Invalid: "Product Name" (Spaces not allowed)



        // Date & Time
        public static readonly string DateFormat = @"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$";
        // ✅ Valid: "2024-01-15" | ❌ Invalid: "15-01-2024" (Wrong format)

        public static readonly string Time24Hour = @"^(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$";
        // ✅ Valid: "23:59" | ❌ Invalid: "25:00" (Hour cannot exceed 23)



        // Security & System
        public static readonly string StrongPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
        // ✅ Valid: "Abc@1234" | ❌ Invalid: "abc123" (Missing uppercase, symbol)
    }


}
