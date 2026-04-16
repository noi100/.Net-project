using System;

namespace BO
{
    // שגיאה עבור קלט לא תקין (למשל ת"ז שלילית או שם ריק)
    [Serializable]
    public class BLInvalidInputException : Exception
    {
        public BLInvalidInputException(string? message) : base(message) { }
        public BLInvalidInputException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // שגיאה עבור ישות שלא קיימת (למשל כשמנסים למצוא לקוח שלא קיים במערכת)
    [Serializable]
    public class BLDoesNotExistException : Exception
    {
        public BLDoesNotExistException(string? message) : base(message) { }
        public BLDoesNotExistException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // שגיאה עבור ישות שכבר קיימת (למשל כשמנסים להוסיף לקוח עם ת"ז קיימת)
    [Serializable]
    public class BLAlreadyExistsException : Exception
    {
        public BLAlreadyExistsException(string? message) : base(message) { }
        public BLAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // שגיאה כללית עבור בעיות בלוגיקה של ה-BL
    [Serializable]
    public class BLLogicException : Exception
    {
        public BLLogicException(string? message) : base(message) { }
        public BLLogicException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
