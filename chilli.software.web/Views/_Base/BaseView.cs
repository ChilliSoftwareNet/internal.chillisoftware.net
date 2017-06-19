using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using chilli.software.common.Model.Const;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace chilli.software.web.Views._Base
{
    public abstract class BaseView<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BaseView()
        {
            LocalizationSourceName = AppConst.AppName;
        }
    }
}