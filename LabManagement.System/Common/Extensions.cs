using Lab.Management.Common;
using Lab.Management.Entities;
using LabManagement.System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LabManagement.System.Common
{
    public static class Extensions
    {
        private static string dateFormat = "MM/dd/yyyy";
        private static string ISTDateFormat = "dd/MM/yyyy";
        public static string IstDateConversion(this DateTime inDateTime)
        {
            return inDateTime.ToString(ISTDateFormat);
        }

        public static string IstDateFormat(this string inDateValue)
        {
            return string.IsNullOrEmpty(inDateValue) ? "N/A" : inDateValue.ToLmsSystemDate().ToString(ISTDateFormat);
        }

        public static string ParseIstDate(this DateTime? inDateTime)
        {
            return inDateTime.HasValue ? inDateTime.Value.ToString(ISTDateFormat) : "N/A";
        }

        public static bool doubleIsNotNull(this double? inValue)
        {
            return inValue.HasValue && inValue.Value > 0.00;
        }

        public static bool stringIsNotNull(this string inValue)
        {
            return !string.IsNullOrEmpty(inValue);
        }

        public static bool dateTimeIsNotNull(this DateTime? inValue)
        {
            return inValue.HasValue;
        }

        public static bool intIsNotNull(this int? inValue)
        {
            return inValue.HasValue && inValue.Value > 0;
        }

        public static string ParseGender(this int? inValue)
        {
            return inValue.HasValue ? inValue.Value == 1 ? "Male" : "Female" : "";
        }

        public static string IsMedicineExpired(this DateTime? inValue)
        {
            var isExpired = "Expired";
            var currentDate = DateTime.Now.ToString(dateFormat);
            if (!inValue.HasValue)
            {
                return "Valid";
            }
            isExpired = currentDate.Equals(inValue.Value.ToString(dateFormat)) ? "Expired" : "Valid";

            return isExpired;
        }

        public static int parseNullInt(this int? inValue)
        {
            return inValue.HasValue ? inValue.Value : 0;
        }

        public static double parseNullDouble(this double? inValue)
        {
            return inValue.HasValue ? inValue.Value : 0.00;
        }

        public static bool IsTwin(this lmsPatientDischargeSummary inlmsPatientDischargeSummary)
        {
            return inlmsPatientDischargeSummary.PWEIGHT2.doubleIsNotNull() ||
                inlmsPatientDischargeSummary.SEX2.stringIsNotNull() ||
                inlmsPatientDischargeSummary.DDATE2.HasValue ||
                inlmsPatientDischargeSummary.DTIME2.stringIsNotNull();
        }

        public static double MedicineExpiryDays(this DateTime? inValue)
        {
            double expiryDate = 0;
            if (inValue != null)
            {
                var currentDate = DateTime.Now;
                expiryDate = (inValue.Value - currentDate).TotalDays;
            }
            return Math.Round(expiryDate);
        }

        public static SelectList GetInPatientDropdowList(this IList<lmsPatientRegistration> inValue, object seletedValue = null)
        {
            inValue.ToList().ForEach(x =>
            {
                x.PATIENTNAME = string.Format("{0} - {1}", x.PATIENTID, x.PATIENTNAME);
            });
            var dropDownList = new SelectList(inValue, "PATIENTID", "PATIENTNAME", seletedValue);
            return dropDownList;
        }

        public static SelectList GetDropDownList<T>(this IList<T> inList, string dataValueField, string dataTextField)
        {
            return new SelectList(inList, dataValueField, dataTextField);
        }

        public static string GetDisplayCssByRole(this usp_ValidateUser_Result userInfo)
        {
            var userRole = userInfo == null ? string.Empty : userInfo.ROLENAME;
            var hiddenClass = userRole.ToUpper() == "ADMIN" || userRole.ToUpper() == "DOCTOR" ? "display-by-role" : "hidden-by-role";
            return hiddenClass;
        }

        public static bool IsAdmin(this usp_ValidateUser_Result userInfo)
        {
            var userRole = userInfo == null ? string.Empty : userInfo.ROLENAME;
            if(userRole == null)
            {
                return false;
            }
            return userRole.ToUpper() == "ADMIN" || userRole.ToUpper() == "DOCTOR";
        }

        public static bool IsTestUser(this usp_ValidateUser_Result userInfo)
        {
            var userRole = userInfo == null ? string.Empty : userInfo.ROLENAME;
            //if(userRole==null)
            //{
            //    return false;
            //}
            return userRole.ToUpper() == "TEST";
        }

        public static bool HasPrescription(this ICollection<lmsPatientPrescription> lmsPatientPrescriptions, int bookingId)
        {
            return lmsPatientPrescriptions != null && lmsPatientPrescriptions.Any(x => x.BOOKINGID == bookingId);
        }
        public static string GetTransactionMessage(this string transaction)
        {
            if(string.IsNullOrEmpty(transaction))
            {
                return string.Empty;
            }
            TransactionType transactionType = (TransactionType)Enum.Parse(
                                          typeof(TransactionType), transaction, true);
            switch (transactionType)
            {
                case TransactionType.Save:
                    return "Item saved successfully";
                case TransactionType.Remove:
                    return "Item removed successfully";
                case TransactionType.RemoveError:
                    return "Error in removing item,please try again later";
                case TransactionType.SaveError:
                    return "Error in saving item,please try again later";
                default:
                    return string.Empty;

            }
        }
    }
}
