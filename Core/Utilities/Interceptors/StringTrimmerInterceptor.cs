using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Z.EntityFramework.Extensions;

namespace Core.Utilities.Interceptors
{
    public class StringTrimmerInterceptor : DbCommandInterceptor
    {
        public void StringTrimmer(DbCommand command)
        {
            string nameTrim = "RTRIM([t].[Name])";
            string komut = command.CommandText.Replace("[t].[Name]", nameTrim);
            command.CommandText = komut;
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            var anan = eventData.Context.Model.GetEntityTypes();
            foreach (Microsoft.EntityFrameworkCore.Metadata.IEntityType tip in anan)
            {
                var alts = tip.ClrType.GetProperties();
                foreach (System.Reflection.PropertyInfo alt in alts)
                {
                    var sonuc = alt.PropertyType.Name;
                }
            }
            StringTrimmer(command);
            return result;
        }

        //public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        //{
        //    StringTrimmer(command);
        //    base.ReaderExecuting(command, interceptionContext);
        //}
    }
}
