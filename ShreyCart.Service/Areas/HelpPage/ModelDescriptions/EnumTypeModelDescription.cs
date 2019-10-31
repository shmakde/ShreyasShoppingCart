// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShreyCart.Service.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}