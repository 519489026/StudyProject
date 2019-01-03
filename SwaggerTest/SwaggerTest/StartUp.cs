using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwaggerTest
{
    public class StartUp
    {


        public static IApplicationBuilder UseDefaultConfig(this IApplicationBuilder app, IHostingEnvironment env, Action<SwaggerUIOptions> swaggerUIOptions)
        {
            app.UseDefaultConfig(env);
            app.UseSwagger()
               .UseSwaggerUI(options =>
               {
                   swaggerUIOptions.Invoke(options);
               });
            return app;
        }
    }
}