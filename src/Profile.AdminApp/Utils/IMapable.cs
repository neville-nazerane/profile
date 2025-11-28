using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.Utils
{
    public interface IMapable<TModel>
    {

        TModel ToModel();

        void FromModel(TModel model);

    }
}
