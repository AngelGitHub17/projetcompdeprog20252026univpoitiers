/* Fichier MainWindow.axaml.cs
 * Gère l'interface du jeu de Tetris : la fenêtre graphique et 
 * l'ensemble des interactions du jeu.
 * Auteur : ...
 * Version : alpha
 */

using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using System;
using Avalonia.Threading;
// à ajouter à partir de l'itération 1
using NoyauTetris;

namespace InterfaceTetris;

/* Gère la fenêtre principale du jeu de Tetris, et l'ensemble des interactions du jeu. */
public partial class MainWindow : Window
{
    /* Minuteur qui déclanche régulièrement un évènement. */
    public DispatcherTimer Minuteur;
    
    public MainWindow()
    {
        InitializeComponent();
        // Défini la taille de la fenêtre à partir des constantes
        Width = 300;
        Height = 600;
        // Définit le texte de InfoText
        InfoText.Text = "Zone de texte";
        // Défini la taille du canvas à partir des constantes
        TetrisCanvas.Width = 200;
        TetrisCanvas.Height = 400;
        // Défini la taille des boutons à partir des constantes
        StartButton.Width = 200;
        StartButton.Height = 30;
        QuitButton.Width = 200;
        QuitButton.Height = 30; 
        // Initialise le minuteur pour faire descendre le tetrino courant toutes les 500 milisecondes
        Minuteur = new DispatcherTimer();
        Minuteur.Interval = TimeSpan.FromMilliseconds(500);
        Minuteur.Tick += (s, e) => { BasInterface();};   
        // détecte le clic sur le bouton Démarrer, déclanche l'évènement Demarrer, puis appelle la méthode DemarrerTetris
        StartButton.Click += (s, e) => { DemarrerInterface();};
        // détecte le clic sur le bouton Quitter, déclanche l'évènement Quiter, puis ferme la fenêtre
        QuitButton.Click += (s, e) => { Close();};
        // détecte la pression d'une touche du clavier, et déclanche l'évènement correspondant
        KeyDown += (s, e) =>
        {
            // Choix des touches à modifier si besoin (voir la documentation de l'énumération Key)
            if (e.Key == Key.Left)
            {
                GaucheInterface();
            }
            else if (e.Key == Key.Right)
            {
                DroiteInterface();
            }
            else if (e.Key == Key.X)
            // si vous disposer d'un pavé numérique, choisir Key.PageUp
            {
                RotationDroiteInterface();
            }
            else if (e.Key == Key.W)
            // si vous disposer d'un pavé numérique, choisir Key.Home
            {
                RotationGaucheInterface();
            }
            else if (e.Key == Key.Down)
            {
                TombeInterface();
            }
        };
    } 

    /* Dessine un rectangle dans le TetrisCanvas, à la position (x, y), de largeur width, 
    de hauteur height (en pixels) et de couleur couleur. */
    public void DessinerRectangle(int x, int y, int with, int height, Avalonia.Media.IBrush couleur)
    {
        TetrisCanvas.Children.Add(new Avalonia.Controls.Shapes.Rectangle
        {
            Width = with,
            Height = height,
            Fill = couleur,
            Margin = new Thickness(x, y, 0, 0) 
        });
    }

    public void DessinerCadre()
    {
        // Fond blanc
        DessinerRectangle(10, 0, 180, 390, Avalonia.Media.Brushes.White);
    }

    /*Cette fonction permet de démarrer le Jeu*/
    public void DemarrerInterface()
    {
        // Vider la zone graphique
        TetrisCanvas.Children.Clear();

        // Dessiner le cadre
        DessinerCadre();
        // Dessiner les 3 carrés
        DessinerRectangle(10, 0, 10, 10, Avalonia.Media.Brushes.Pink);
        DessinerRectangle(20, 10, 10, 10, Avalonia.Media.Brushes.Purple);
        DessinerRectangle(30, 20, 10, 10, Avalonia.Media.Brushes.Blue);
    }

    /*Cette fonction permet de déplacer le tétrominos à droite*/
    public void DroiteInterface()
    {
        Console.WriteLine("Déplacement à droite à coder...");
    }

    /*Cette fonction permet de déplacer le tétrominos à gauche*/
    public void GaucheInterface()
    {
        Console.WriteLine("Déplacement à gauche à coder...");
    }

    /*Cette fonction permet de forcer le déplacement du tétrominos vers le bas*/
    public void BasInterface()
    {
        Console.WriteLine("Déplacement en bas à coder...");
    }

    /*Cette fonction permet de forcer le déplacement du tétrominos vers le bas*/
    public void TombeInterface()
    {
        Console.WriteLine("Déplacement rapide en bas à coder...");

    }

    /*Cette fonction permet de faire une rotation du tétrominos vers la droite*/
    public void RotationDroiteInterface()
    {
        Console.WriteLine("Rotation à droit à coder...");
    }

    /*Cette fonction permet de faire une rotation du tétrominos vers la gauche*/
    public void RotationGaucheInterface()
    {
        Console.WriteLine("Rotation à gauche à coder...");
    }
}

public interface IBrush
{
}