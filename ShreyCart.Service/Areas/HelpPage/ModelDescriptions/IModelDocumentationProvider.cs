// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System;
using System.Reflection;

namespace ShreyCart.Service.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}