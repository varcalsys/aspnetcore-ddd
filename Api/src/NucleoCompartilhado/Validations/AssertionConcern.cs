using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NucleoCompartilhado.DomainEvents.Events;
using NucleoCompartilhado.DomainEvents.Notifications.DomainNotifications;

namespace NucleoCompartilhado.Validations
{
    public static class AssertionConcern
    {
        public static bool IsValid(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            var domainNotifications = notificationsNotNull as IList<DomainNotification> ?? notificationsNotNull.ToList();
            NotifyAll(domainNotifications);

            return domainNotifications.Count().Equals(0);
        }


        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(validation => { DomainEvent.RaiseEvent(validation); });
        }

        public static DomainNotification AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            var length = stringValue.Trim().Length;

            return (length < minimum || length > maximum)
                ? new DomainNotification("AssertArgumentLength", message)
                : null;
        }

        public static DomainNotification AssertMatches(string pattern, string stringValue, string message)
        {
            var regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue))
                ? new DomainNotification("AssertArgumentLength", message)
                : null;
        }

        public static DomainNotification AssertNotEmpty(string stringValue, string message)
        {
            return (string.IsNullOrEmpty(stringValue))
                ? new DomainNotification("AssertArgumentNotEmpty", message)
                : null;
        }

        public static DomainNotification AssertNotNull(object object1, string message)
        {
            return (object1 == null)
                ? new DomainNotification("AssertArgumentNotNull", message)
                : null;
        }

        public static DomainNotification AssertIsNull(object object1, string message)
        {
            return (object1 != null)
                ? new DomainNotification("AssertArgumentNull", message)
                : null;
        }

        public static DomainNotification AssertTrue(bool boolValue, string message)
        {
            return (!boolValue)
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }

        public static DomainNotification AssertAreEquals(string value, string match, string message)
        {
            return (!(value == match))
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }

        public static DomainNotification AssertIsGreaterThan(int value, int expected, string message)
        {
            return (!(value > expected))
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }

        public static DomainNotification AssertIsGreaterThan(decimal value, decimal expected, string message)
        {
            return (!(value > expected))
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }

        public static DomainNotification AssertIsGreaterOrEqualThan(int value, int expected, string message)
        {
            return (!(value >= expected))
                ? new DomainNotification("AssertArgumentTrue", message)
                : null;
        }

        public static DomainNotification AssertRegexMatch(string value, string regex, string message)
        {
            return (!Regex.IsMatch(value, regex, RegexOptions.IgnoreCase))
                ? new DomainNotification("AssertRegexNotMatch", message)
                : null;
        }

        public static DomainNotification AssertEmailIsValid(string email, string message)
        {
            var emailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            return (!Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase))
                ? new DomainNotification("AssertEmailIsInvalid", message)
                : null;
        }

        public static DomainNotification AssertUrlIsValid(string url, string message)
        {
            // Do not validate if no URL is provided
            // You can call AssertNotEmpty before this if you want
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            var regex = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

            return (!Regex.IsMatch(url, regex, RegexOptions.IgnoreCase)) ? new DomainNotification("AssertUrlIsInvalid", message) : null;
        }

        public static DomainNotification AssertOnlyNumber(string stringValue, string message)
        {
            var regex = new Regex(@"^[0-9]+$");

            return (!regex.IsMatch(stringValue))
                ? new DomainNotification("AssertOnlyNumberInvalid", message)
                : null;
        }

        public static DomainNotification AssertNameIsValid(string stringValue, string message)
        {
            var regex = new Regex(@"^([\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+((\s[\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+)?$");

            return (!regex.IsMatch(stringValue))
                ? new DomainNotification("AssertNameInvalid", message)
                : null;
        }

        public static DomainNotification AssertPhoneIsValid(string numberPhone, string message)
        {
            var regex = new Regex(@"^[0-9]{10}$");

            return (!regex.IsMatch(numberPhone))
                ? new DomainNotification("AssertOnlyNumberInvalid", message)
                : null;
        }

        public static DomainNotification AssertCnpjIsValid(string cnpj, string message)
        {
            var regex = new Regex(@"^[0-9]{14}$");

            return (!regex.IsMatch(cnpj))
                ? new DomainNotification("AssertCNPJInvalid", message)
                : null;
        }

        public static DomainNotification AssertCpfIsValid(string cnpj, string message)
        {
            var regex = new Regex(@"^[0-9]{11}$");

            return (!regex.IsMatch(cnpj))
                ? new DomainNotification("AssertCPFInvalid", message)
                : null;
        }
    }
}
