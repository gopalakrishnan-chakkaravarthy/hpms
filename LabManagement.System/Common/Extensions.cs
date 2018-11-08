﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab.Management.Entities;
using System.Web.Mvc;
using System.Globalization;
using Lab.Management.Common;
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
    }

}