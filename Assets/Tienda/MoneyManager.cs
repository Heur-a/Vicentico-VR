using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance {get; private set;}
    public int galletas = 0;

    public delegate void NotifyMoneyChange(int money);
    public static event NotifyMoneyChange OnMoneyChanged;
    private void Start()
    {
        if (instance == null) instance = this;
        else DestroyImmediate(this);
        DontDestroyOnLoad(instance);
    }

    public void ActualizarGalletas(int deltaGalletas)
    {
        int galletasTemp = galletas;
        galletasTemp += deltaGalletas;
        if(galletasTemp < 0) galletasTemp = 0;
        galletas = galletasTemp;
        NotificarCambioMoney();
    }

    public int GetGalleta()
    {
        return galletas;
    }
    private void NotificarCambioMoney()
    {
        OnMoneyChanged?.Invoke(galletas);
    }
    
}
