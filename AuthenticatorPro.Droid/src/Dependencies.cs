// Copyright (C) 2022 jmh
// SPDX-License-Identifier: GPL-3.0-only

using Android.Content;
using AuthenticatorPro.Droid.Persistence;
using AuthenticatorPro.Droid.Shared.Data;
using AuthenticatorPro.Droid.Shared.View;
using AuthenticatorPro.Droid.Shared.View.Impl;
using AuthenticatorPro.Shared.Data;
using AuthenticatorPro.Shared.Persistence;
using AuthenticatorPro.Shared.Service;
using AuthenticatorPro.Shared.Service.Impl;
using AuthenticatorPro.Shared.View;
using AuthenticatorPro.Shared.View.Impl;
using TinyIoC;

namespace AuthenticatorPro.Droid
{
    internal static class Dependencies
    {
        private static readonly TinyIoCContainer Container = TinyIoCContainer.Current;

        public static void Register()
        {
            Container.Register<Database>().AsSingleton();
            Container.Register<IAssetProvider, AssetProvider>();
            Container.Register<ICustomIconDecoder, CustomIconDecoder>();
            Container.Register<IIconResolver, IconResolver>();

            RegisterRepositories(Container);
            RegisterServices(Container);
            RegisterViews(Container);
        }

        public static void RegisterApplicationContext(Context context)
        {
            Container.Register(context);
        }

        public static TinyIoCContainer GetChildContainer()
        {
            return Container.GetChildContainer();
        }

        public static void RegisterRepositories(TinyIoCContainer container)
        {
            container.Register<IAuthenticatorRepository, AuthenticatorRepository>();
            container.Register<ICategoryRepository, CategoryRepository>();
            container.Register<IAuthenticatorCategoryRepository, AuthenticatorCategoryRepository>();
            container.Register<ICustomIconRepository, CustomIconRepository>();
        }

        public static void RegisterServices(TinyIoCContainer container)
        {
            container.Register<IAuthenticatorCategoryService, AuthenticatorCategoryService>();
            container.Register<IAuthenticatorService, AuthenticatorService>();
            container.Register<IBackupService, BackupService>();
            container.Register<ICategoryService, CategoryService>();
            container.Register<ICustomIconService, CustomIconService>();
            container.Register<IImportService, ImportService>();
            container.Register<IQrCodeService, QrCodeService>();
            container.Register<IRestoreService, RestoreService>();
        }

        public static void RegisterViews(TinyIoCContainer container)
        {
            container.Register<IAuthenticatorView, AuthenticatorView>().AsMultiInstance();
            container.Register<ICategoryView, CategoryView>().AsMultiInstance();
            container.Register<IIconView, IconView>().AsMultiInstance();
        }

        public static T Resolve<T>() where T : class
        {
            return Container.Resolve<T>();
        }
    }
}