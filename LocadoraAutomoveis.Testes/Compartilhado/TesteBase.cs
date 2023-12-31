﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.Serialization;

namespace LocadoraAutomoveis.Testes.Compartilhado
{
    public static class TesteBase
    {
        public static DbUpdateException CriarDbUpdateException(string message)
        {
            var sqlException = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(sqlException, message);

            DbUpdateException dbUpdateException = (DbUpdateException)FormatterServices.GetUninitializedObject(typeof(DbUpdateException));
            FieldInfo innerExceptionField = typeof(Exception).GetField("_innerException", BindingFlags.Instance | BindingFlags.NonPublic);

            innerExceptionField?.SetValue(dbUpdateException, sqlException);
            return dbUpdateException;
        }
    }
}
