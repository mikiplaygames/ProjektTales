using AngouriMath;
using AngouriMath.Extensions;
using ProjektTales.ViewModels;
using ProjektTales.Model;

namespace ProjektTales;

public partial class EquationUsePage : ContentPage
{
    public EquationUsePage(EquationUseViewModel equationUseViewModel)
	{
		InitializeComponent();
        BindingContext = equationUseViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
    
    Entity selectedExpr;
    EquationStats es;
    Dictionary<string, float> variables = new();

    private void Calculate_Clicked(object sender, EventArgs e)
    {
        Entity createdExpr = selectedExpr;
        foreach (var pair in variables)
        {
            createdExpr = createdExpr.Substitute(pair.Key, pair.Value);
        }
        string answer = createdExpr.EvalNumerical().ToString();
        result.Text = selectedExpr.ToString() + "  |  " + createdExpr.ToString() + "  |  " + answer;
    }

    private void Input_Changed(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;
        string variable = entry.Placeholder;

        float.TryParse(entry.Text, out float value);
        
        if (variables.ContainsKey(variable))
            variables[variable] = value;
        else
            variables.Add(variable, value);
    }

    private void Page_Loaded(object sender, EventArgs e)
    {
        ContentPage page = (ContentPage)sender;
        EquationUseViewModel useViewModel = (EquationUseViewModel)page.BindingContext;
        es = useViewModel.EquationStats;
        selectedExpr = es.MathExpression;
    }
}