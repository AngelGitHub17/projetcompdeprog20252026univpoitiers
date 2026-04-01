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
    // Dimensions de la grille de jeu
    public int LargeurGrille; // Nombre de colonnes
    public int HauteurGrille; // Nombre de lignes

    // Le tetrino actuellement en jeu
    public Tetrino TetrinoCourant;

    // Position absolue du tetrino sur la grille (coin supérieur gauche du tetrino)
    public Position PositionCourante;

    public JeuTetris()
    {
        LargeurGrille = 12;
        HauteurGrille = 15;
        TetrinoCourant = new Tetrino();
        PositionCourante = new Position(LargeurGrille / 2, 0);
    }

    public void Demarrer()
    {
        // Initialise ou réinitialise l'état du jeu
        TetrinoCourant = new Tetrino();
        PositionCourante = new Position(LargeurGrille / 2, 0);

        Console.WriteLine("Démarrage du jeu...");
        Console.WriteLine("Tetrino courant initialisé.");
    }

    public void Droite()
    {
        // Cette méthode déplace le tetrino courant d'une case vers la droite.
        // Elle vérifie d'abord si le déplacement est possible sans sortir du cadre.

        bool peutSeDeplacer = true; // Variable pour indiquer si le déplacement est autorisé

        // Pour chaque position relative du tetrino (les blocs qui le composent)
        foreach (var positionRelative in Tetrino.TetrinosTab[TetrinoCourant.ShapeIndex])
        {
            // Calcule la position absolue après déplacement : position actuelle + position relative + 1 (pour droite)
            int nouvellePositionX = PositionCourante.X + positionRelative.X + 1;

            // Si cette nouvelle position dépasse la largeur de la grille, on ne peut pas se déplacer
            if (nouvellePositionX >= LargeurGrille)
            {
                peutSeDeplacer = false;
                break; // Pas besoin de vérifier les autres blocs
            }
        }

        // Si le déplacement est possible, on met à jour la position du tetrino
        if (peutSeDeplacer)
        {
            PositionCourante.X += 1;
        }
        // Sinon, le tetrino reste à sa place (il ne bouge pas)
    }

    public void Gauche()
    {
        // Cette méthode déplace le tetrino courant d'une case vers la gauche.
        // Elle vérifie d'abord si le déplacement est possible sans sortir du cadre.

        bool peutSeDeplacer = true; // Variable pour indiquer si le déplacement est autorisé

        // Pour chaque position relative du tetrino (les blocs qui le composent)
        foreach (var positionRelative in Tetrino.TetrinosTab[TetrinoCourant.ShapeIndex])
        {
            // Calcule la position absolue après déplacement : position actuelle + position relative - 1 (pour gauche)
            int nouvellePositionX = PositionCourante.X + positionRelative.X - 1;

            // Si cette nouvelle position est négative (sort à gauche), on ne peut pas se déplacer
            if (nouvellePositionX < 0)
            {
                peutSeDeplacer = false;
                break; // Pas besoin de vérifier les autres blocs
            }
        }

        // Si le déplacement est possible, on met à jour la position du tetrino
        if (peutSeDeplacer)
        {
            PositionCourante.X -= 1;
        }
        // Sinon, le tetrino reste à sa place (il ne bouge pas)
    }

    public void Bas()
    {
        // Cette méthode déplace le tetrino courant d'une case vers le bas.
        // Si le tetrino atteint le bas de la grille, il disparaît et un nouveau tetrino apparaît en haut.

        bool peutSeDeplacer = true; // Variable pour indiquer si le déplacement est autorisé

        // Pour chaque position relative du tetrino (les blocs qui le composent)
        foreach (var positionRelative in Tetrino.TetrinosTab[TetrinoCourant.ShapeIndex])
        {
            // Calcule la position absolue après déplacement : position actuelle + position relative + 1 (pour bas)
            int nouvellePositionY = PositionCourante.Y + positionRelative.Y + 1;

            // Si cette nouvelle position dépasse la hauteur de la grille, on ne peut pas se déplacer
            if (nouvellePositionY >= HauteurGrille)
            {
                peutSeDeplacer = false;
                break; // Pas besoin de vérifier les autres blocs
            }
        }

        // Si le déplacement est possible, on met à jour la position du tetrino
        if (peutSeDeplacer)
        {
            PositionCourante.Y += 1;
        }
        else
        {
            // Le tetrino a atteint le bas : on crée un nouveau tetrino en haut de la grille
            TetrinoCourant = new Tetrino();
            PositionCourante = new Position(LargeurGrille / 2, 0);
        }
    }

    public void Tombe()
    {
        // Cette méthode fait tomber le tetrino courant directement jusqu'en bas de la grille.
        // Ensuite, un nouveau tetrino apparaît en haut.

        // Boucle tant que le tetrino peut descendre
        while (true)
        {
            bool peutSeDeplacer = true; // Variable pour indiquer si le déplacement vers le bas est possible

            // Pour chaque position relative du tetrino (les blocs qui le composent)
            foreach (var positionRelative in Tetrino.TetrinosTab[TetrinoCourant.ShapeIndex])
            {
                // Calcule la position absolue après déplacement : position actuelle + position relative + 1 (pour bas)
                int nouvellePositionY = PositionCourante.Y + positionRelative.Y + 1;

                // Si cette nouvelle position dépasse la hauteur de la grille, on ne peut pas descendre plus
                if (nouvellePositionY >= HauteurGrille)
                {
                    peutSeDeplacer = false;
                    break; // Pas besoin de vérifier les autres blocs
                }
            }

            // Si on peut descendre, on met à jour la position
            if (peutSeDeplacer)
            {
                PositionCourante.Y += 1;
            }
            else
            {
                // On ne peut plus descendre : on sort de la boucle
                break;
            }
        }

        // Maintenant que le tetrino est arrivé en bas, on crée un nouveau tetrino en haut
        TetrinoCourant = new Tetrino();
        PositionCourante = new Position(LargeurGrille / 2, 0);
    }
};

public class Position
{
    // Coordonnées X et Y (colonnes et lignes sur la grille)
    public int X;
    public int Y;

    // Constructeur pour créer une position
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Méthodes pour déplacer la position (utilisées pour les positions relatives des tetrinos)
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
    // Index de la forme du tetrino (0 = carré, 1 = barre horizontale, 2 = barre verticale, etc.)
    public int ShapeIndex;

    // Tableau statique contenant les formes des tetrinos.
    // Chaque forme est un tableau de positions relatives (par rapport au coin supérieur gauche du tetrino)
    public static Position[][] TetrinosTab = new Position[][]
    {
        // carre : 4 blocs en forme de carré
        new Position[] { new Position(0, 0), new Position(1, 0),
            new Position(0, -1), new Position(1, -1) },
        // barre horizontale : 4 blocs alignés horizontalement
        new Position[] { new Position(0, 0), new Position(1, 0),
            new Position(2, 0), new Position(3, 0) },
        // barre verticale : 4 blocs alignés verticalement
        new Position[] { new Position(0, 0), new Position(0, -1),
            new Position(0, -2), new Position(0, -3) }
    };

    // Constructeur : initialise le tetrino avec la première forme (pour l'instant)
    public Tetrino()
    {
        ShapeIndex = 0; // Pour l'instant, forme fixe (carré)
    }
};