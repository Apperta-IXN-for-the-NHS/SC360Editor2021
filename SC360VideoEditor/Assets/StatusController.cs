﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class StatusController : MonoBehaviour
{
    private string projectName;
    private string projectPath;

    public GameObject projectNameDisplay;
    public GameObject projectPathDisplay;

    private string init_project_name;
    private string init_project_path;
    private bool init_set;

    void Start()
    {
        init_set = false;
    }

    public void setNameAndPath(string project_name, string project_path)
    {
        projectName = project_name;
        projectPath = project_path;
        displayNameAndPath();
        if (!init_set) {
            init_project_name = projectName;
            init_project_path = projectPath;
            init_set = true;
        }
    }

    public string getName()
    {
        return projectName;
    }

    public string getPath()
    {
        return projectPath;
    }

    public bool path_ready()
    {
        return projectPath != null || projectPath != "";
    }

    //Add the set name and path to the displays.
    public void displayNameAndPath()
    {
        projectNameDisplay.GetComponent<Text>().text = projectName;
        projectPathDisplay.GetComponent<Text>().text = projectPath;
    }

    //Used when switch from main video to branch.
    public void branch_out(string hotspot_name)
    {
        projectName = Path.Combine(projectName, hotspot_name);
        projectPath = Path.Combine(projectPath, hotspot_name);
        displayNameAndPath();
    }

    //Used when switch to branch using nodes on the timeline.
    public void branch_into(string hotspot)
    {
        projectName = init_project_name + hotspot;
        projectPath = init_project_path + hotspot;
        displayNameAndPath();
    }

    //Used when switch from branch to the main video.
    public void branch_back()
    {
        projectName = Path.GetDirectoryName(projectName);
        projectPath = Directory.GetParent(projectPath).FullName;
        displayNameAndPath();
    }

    public string mainVideoPath()
    {
        return Path.Combine(projectPath, "MainVideo.mp4");
    }

    public string getRootProjectName()
    {
        return init_project_name;
    }

    public string getRootProjectPath()
    {
        return init_project_path;
    }
}
