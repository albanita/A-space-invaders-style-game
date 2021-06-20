using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Plugins;

public class CanvasInteract : MonoBehaviour
{
    public GameObject panel;
    public Dropdown dropdown;
    public GameObject inputText;
    public GameObject controlsPanel;
    
    private Text text;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        Player pl = Persistencia.getActivePlayer();
        if(pl != null)
        {
            text.text = pl.Name + ", " + pl.Points + " points";
        }
        updatePlayersList();
    }

    public void updatePlayersList()
    {
        List<Player> players = Persistencia.getAllPlayers();
        dropdown.options.Capacity = players.Count;
        dropdown.options.Clear();
        List<string> names = new List<string>();
        foreach (Player p1 in players)
        {
            names.Add(p1.Name);
        }
        dropdown.AddOptions(names);
    }

    public void changeActivePlayer()
    {
        string nume = dropdown.captionText.text;
        Player player = Persistencia.getPlayer(nume);
        Persistencia.setPlayerActive(player);
        hidePanel(player);
    }

    public void addPlayer()
    {
        string nume = inputText.GetComponent<InputField>().text;
        Player pl = new Player(nume, 0);
        Persistencia.addPlayer(pl);
        inputText.GetComponent<InputField>().text = "";
        updatePlayersList();
        hidePanel(pl);
    }

    private void hidePanel(Player player)
    {
        text.text = player.Name + ", " + player.Points + " points";
        panel.SetActive(false);
    }

    public void showHidePanel()
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void showHideControls()
    {
        if (!controlsPanel.activeSelf)
        {
            controlsPanel.SetActive(true);
        }
        else
        {
            controlsPanel.SetActive(false);
        }
    }

    public void openPage()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCUaPJ8oeOC6xsVOZtmszvxw");
    }
}
