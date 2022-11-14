using AngouriMath;
using ProjektTales.ViewModels;

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
    Dictionary<string, string> variables = new();

    private void Calculate_Clicked(object sender, EventArgs e)
    {
        Entity createdExpr = selectedExpr;
        
        foreach (var pair in variables)
        {
            Entity val = pair.Value;
            if (val.EvaluableNumerical)
                createdExpr = createdExpr.Substitute(pair.Key, val.EvalNumerical());
            else
                createdExpr = createdExpr.Substitute(pair.Key, pair.Value);
        }
        
        if (createdExpr.EvaluableNumerical)
        {
            string answer = createdExpr.EvalNumerical().ToString();
            result.Text = selectedExpr.ToString() + "  |  " + createdExpr.ToString() + "  |  " + answer;
        }
        else
            result.Text = "Expression is not evaluable";
    }

    private void Input_Changed(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;
        string variable = entry.Placeholder;
        
        if (variables.ContainsKey(variable))
            variables[variable] = entry.Text;
        else
            variables.Add(variable, entry.Text);
    }

    private void Page_Loaded(object sender, EventArgs e)
    {
        ContentPage page = (ContentPage)sender;
        EquationUseViewModel useViewModel = (EquationUseViewModel)page.BindingContext;
        es = useViewModel.EquationStats;
        selectedExpr = es.MathExpression;
    }
}