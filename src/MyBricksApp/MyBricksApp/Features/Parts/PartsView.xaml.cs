using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBricksApp.Features.Parts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartsView : ContentPage
    {
        public PartsView()
        {
            InitializeComponent();
        }
    }
}