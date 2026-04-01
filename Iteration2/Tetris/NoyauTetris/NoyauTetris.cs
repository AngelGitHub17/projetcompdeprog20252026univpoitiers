namespace NoyauTetris;

public enum Couleur
{
    Bleu,
    Rose,
    Violet,
    Blanc,
    Noir
    
}
public class JeuTetris
{
    public int LargeurGrille;
    public int HauteurGrille;
    public Tetrino TetrinoCourant;

    public JeuTetris()
    {
        LargeurGrille = 12;
        HauteurGrille = 15;
        TetrinoCourant = new Tetrino();
    }

    public void Demarrer()
    {
        // Initialise ou réinitialise l'état du jeu
        TetrinoCourant = new Tetrino();

        Console.WriteLine("Démarrage du jeu...");
        Console.WriteLine("Tetrino courant initialisé.");
    }

    public void Droite()
    {
    }

    public void Gauche()
    {
    }

    public void Bas()
    {
    }

    public void Tombe()
    {
    }
};

public class Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void gauche()
    {
        X--;
    }

    public void droite()
    {
        X++;
    }

    public void bas()
    {
        Y++;
    }

};

public class Tetrino
{
    public static Position[][] TetrinosTab = new Position[][]
    {
        // carre
        new Position[] { new Position(0, 0), new Position(1, 0),
            new Position(0, -1), new Position(1, -1) },
        // barre horizontale
        new Position[] { new Position(0, 0), new Position(1, 0),
            new Position(2, 0), new Position(3, 0) },
        // barre verticale
        new Position[] { new Position(0, 0), new Position(0, -1),
            new Position(0, -2), new Position(0, -3) }
    };
};