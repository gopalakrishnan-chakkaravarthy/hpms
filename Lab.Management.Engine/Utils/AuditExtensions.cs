﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lab.Management.Engine.Utils
//{   /// <summary>
//    /// An extension class for <see cref="AuditLog"/>.
//    /// </summary>
//    public static class AuditExtensions
//    {
//        /// <summary>
//        /// Begin audit logging by attaching an <see cref="AuditLogger"/> to the <see cref="ObjectContext"/>.
//        /// </summary>
//        /// <param name="objectContext">The ObjectContext to create the AuditLog from.</param>
//        /// <param name="configuration">The AuditConfiguration to use when creating the AuditLog.</param>
//        /// <returns>An Auditlogger instance to create an AuditLog from.</returns>
//        public static AuditLogger BeginAudit(this ObjectContext objectContext, AuditConfiguration configuration = null)
//        {
//            return new AuditLogger(objectContext, configuration);
//        }

//        /// <summary>
//        /// Begin audit logging by attaching an <see cref="AuditLogger"/> to the <see cref="ObjectContext"/>.
//        /// </summary>
//        /// <param name="dbContext">The DbContext to create the AuditLog from.</param>
//        /// <param name="configuration">The AuditConfiguration to use when creating the AuditLog.</param>
//        /// <returns>An Auditlogger instance to create an AuditLog from.</returns>
//        public static AuditLogger BeginAudit(this DbContext dbContext, AuditConfiguration configuration = null)
//        {
//            return new AuditLogger(dbContext, configuration);
//        }
//    }
//}