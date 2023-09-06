# Un petit test

## L'objectif

Il faudrait que tu crées une application web qui affiche différentes formes sur une page (pour constituer un joli portrait). Ces formes sont décrites dans le fichier JSON que tu as également récupéré. Pour chacune de ces formes (cercle, rectangle ou texte) tu as la position et la taille.

De façon un peu plus précise :

- pour les rectangles
  - tu les affiches avec une bodure pleine noire d'un pixel et un fond blanc (ouais c'est un peu basique)
  - tu t'aides de la position qui est celle du point en haut à gauche, on te donne aussi la largeur et la longueur (on est sympa)
  - tu affiches _optionnellement_ le texte dans une popup quand on clique dessus (c'est rigolo)
- pour les cercles
  - tu les affiches avec une bodure pleine noire d'un pixel et un fond blanc (ouais on se repète)
  - tu t'aides de la position qui est celle du point en haut à gauche de la boite englobant le cercle et on te donne juste la largeur (tu devrais arriver à trouver la hauteur)
  - tu affiches _optionnellement_ le texte dans une popup quand on clique dessus
- pour les textes c'est la position du milieu du texte, on ne te donne pas la largeur, ni la hauteur (par contre si tu peux l'afficher en Arial 40px ce sera plus beau)

Tout ça devrait dessiner quelque chose dans un rectangle de 600x800 pixels.
Il ne faut pas afficher tout ce qui dépasse. Les formes s'empilent dans l'ordre indiqué.

Si tu es fort et motivé, tu peux de façon _optionnelle_ protéger ce site avec une authentification.

Les priorités sont

1. Ca marche (sans les fonctionnalités optionnelles)
2. C'est maintenable
3. C'est joli
4. Ca marche (avec les fonctionnalités optionnelles)

## Le fichier JSON

Ben il est pas compliqué, c'est un tableau de Shapes. Attention, il y a des Shapes autres que les rectangles, cercles et textes que l'on ne veut pas afficher.

## Les technologies

- Le front est en Angular (à défaut en React ou Vue.js) et s'occupe d'afficher toutes ces Shapes
- Le back est en .NET ou en nodejs (ou autre à défaut) et s'occupe d'envoyer toutes les bonnes Shapes au front

## Tes droits

- Tu peux t'aider d'internet (parfois il y a des choses vraies dessus)
- Tu peux être créatif (on aime bien)
- Tu peux nous appeler si tu galères

## Tes devoirs

- Tu as 1 heure et 30 minutes
- Tu travailles tout seul (autrement on le dit à tous tes potes)
- Quand tu as terminé tu nous envoies le code (pas les bin, node_modules etc. stp, on compilera de notre côté) à l'adresse de Yann : yann.faure@slowsense.com

## Conclusion

Allez GO, on est avec toi !
