using System.Globalization;

namespace MonApp.Module.BusinessObjects;

public static class CodeNumHelper
{
    // Valeur réservée aux codes non numériques : ils passent après tous les numériques
    public const long CodeTexte = long.MaxValue;

    public static long Calculer(string code) =>
        long.TryParse(code, NumberStyles.None, CultureInfo.InvariantCulture, out var n) && n < CodeTexte
            ? n
            : CodeTexte;
}