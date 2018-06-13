using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Game{ 

	public static Game current;
	public int difficulty;
	public int [] levels_passed; //0 significa que dicho nivel no ha sido superado pero está disponible.
								//-1 significa que no se ha superado y además no está desbloqueado aún
								// cualquier otro número indica la mayor dificultad a la que se ha superado el escenario.
	public IDictionary<string, int> props_unlocked; //muy similar, 0 significa bloqueado 1 desbloqueado. los props desbloqueados puedes aparecer aleatoriamente al matar
	public IDictionary<string, int> wargear_unlocked; //igual que props, pero en este caso estos objetos se pueden escoger al iniciar la partida.

	public Game () {
		difficulty = 1; //la dificultad por defecto es 1-> fácil
		levels_passed = new int[] {0}; //de momento sólo hay un nivel, que empieza desbloqueado, pero sin superar.
		props_unlocked = new Dictionary<string,int>(); //inicializamos el diccionario
		props_unlocked ["medpack"] = 1; //Los botiquines están disponibles desde el principio.
		props_unlocked ["Long Sword"] = 1; //La espada larga también.
		props_unlocked ["armor"] = 0; // la armadura no.

		wargear_unlocked = new Dictionary<string,int>();
		wargear_unlocked ["Laser Sword"] = 0; //La espada laser no está disponible cómo arma inicial.
		wargear_unlocked ["Spear"] = 0;//la lanza tampoco.
		wargear_unlocked ["Sword with Hook"] = 0;//la espada con gancho tampoco.
	}
	public Game (int difficulty) {
		this.difficulty = difficulty;
		levels_passed = new int[] {0}; //de momento sólo hay un nivel, que empieza desbloqueado, pero sin superar.
		props_unlocked = new Dictionary<string,int>(); //inicializamos el diccionario
		props_unlocked ["medpack"] = 1; //Los botiquines están disponibles desde el principio.
		props_unlocked ["Long Sword"] = 1; //La espada larga también.
		props_unlocked ["armor"] = 0; // la armadura no.

		wargear_unlocked = new Dictionary<string,int>();
		wargear_unlocked ["Laser Sword"] = 0; //La espada laser no está disponible cómo arma inicial.
		wargear_unlocked ["Spear"] = 0;//la lanza tampoco.
		wargear_unlocked ["Sword with Hook"] = 0;//la espada con gancho tampoco.
	}

	}