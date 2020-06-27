
<p align="center">
  <img src="Utility/RC_Logo.png">
</p>

<p align="center">
  <img src="https://img.shields.io/github/v/release/RobotComponents/RobotComponents?include_prereleases&style=flat-square">
  <img src="https://img.shields.io/github/release-date-pre/RobotComponents/RobotComponents?style=flat-square">
  <img src="https://img.shields.io/github/downloads/RobotComponents/RobotComponents/total?style=flat-square">
  <img src="https://img.shields.io/github/license/RobotComponents/RobotComponents?style=flat-square">
  <img src="https://img.shields.io/github/issues-raw/RobotComponents/RobotComponents?style=flat-square">
  <img src="https://img.shields.io/github/issues-closed-raw/RobotComponents/RobotComponents?style=flat-square">
</p>

---

Robot Components is a Plugin for intuitive Robot Programming for ABB robots inside of Rhinoceros Grasshopper. RobotComponents has the following possibilities and advantages: 

- Predefined ABB robots
- Possibility to define your own robot
- Support for external axes
- Possibility to override all the external axis values
- Support for work objects including the support for movable work objects
- An inverse kinematics and forward kinematics component
- Possibility to add your own custom code lines
- Support for setting up a real-time connection with the IRC5 controller

## Getting Started
You can download the latest release directly from this repository's [releases page](https://github.com/RobotComponents/RobotComponents/releases). Unzip the downloaded archive and copy all files in the Grasshopper Components folder (in GH, File > Special Folders > Components Folder). Make sure that all the files are unblocked (right-click on the file and select Properties from the menu. Click Unblock on the General tab). Restart Rhino and you are ready to go!

You can find a collection of example files demonstrating the main features of Robot Components in this repository in the folder [Example Files](https://github.com/RobotComponents/RobotComponents/tree/master/ExampleFiles). You can find the documentation [here](https://robotcomponents.github.io/RobotComponents-Documentation/). Note: The documentation website is currently in development and not complete yet. 

A release on Food4Rhino is planned in the next months. For easy sharing of the download link and the documentation (with e.g. students) you can also use our linktree: https://linktr.ee/RobotComponents

## Credits
![EDEK_logo](/Utility/181101_EDEK-LOGO-01.png)

Robot Components is an open source project developed and initiated by the chair of [Experimental and Digital Design and Construction of the University of Kassel](https://edek.uni-kassel.de/) led by Prof. Eversmann. The technical development is initiated and executed by the research associates and student assistants which are listed [here](https://github.com/RobotComponents/RobotComponents/blob/master/AUTHORS.md).

Robot Components uses the ABB PC SDK for real-time connection to ABB Robots, you can find the .dll used in this project [here](http://developercenter.robotstudio.com/landing).

## Known Issues
Known issues are listed [here](https://github.com/RobotComponents/RobotComponents/issues). If you find a bug, please help us solve it by filing a [report](https://github.com/RobotComponents/RobotComponents/issues/new).

## Roadmap
Please have a look at the open [issues](https://github.com/RobotComponents/RobotComponents/issues) and [projects](https://github.com/RobotComponents/RobotComponents/projects) to know on what we are currently working and what we want to add and change in the future.  

## Contribute
**Bug reports**: Please report bugs at our [issue page](https://github.com/RobotComponents/RobotComponents/issues). 

**Feature requests**: Feature request can be proposed on our [issue page](https://github.com/RobotComponents/RobotComponents/issues). Please include how this feature should work by explaining it in detail and if possible by adding relevant documentation (from e.g. ABB). 

**Code contributions**: We accept code contributions through [pull requests](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/about-pull-requests). For this you have to [fork](https://help.github.com/en/github/getting-started-with-github/fork-a-repo) or [clone](https://help.github.com/en/github/creating-cloning-and-archiving-repositories/cloning-a-repository) this repository. To compile the code all necesarry references are placed in the folder [DLLs](https://github.com/RobotComponents/RobotComponents/tree/master/DLLs). For questions you can contact one of the [developers](https://github.com/RobotComponents/RobotComponents/blob/master/AUTHORS.md). Feel free to add your name to the list with [contributors](https://github.com/RobotComponents/RobotComponents/blob/master/AUTHORS.md) before you make a pull request. 

**Adding support for other brands**: To a certain extent RobotComponents is prepared to implemented the support of other robot brands (e.g. Fanuc and KUKA). RobotComponent is splitted in multiple parts: RobotComponents.dll which contains all the base classes, RobotComponentsGoos.dll which contains the Grasshopper wrapper classses and RobotComponentsABB.gha which contains all the components and parameters. Since we splitted RobotComponents in multiple parts the support for other robot brands can be implemented in a few different ways. For that reason and that we want to keep RobotComponents as intuitive as possible we kindly ask you to contact one of the [developers](https://github.com/RobotComponents/RobotComponents/blob/master/AUTHORS.md) if you want to implement other robot brands. We are happy to contribute to and support this development.

## Cite RobotComponents
RobotComponents is a free to use Grasshopper plugin and does not legally bind you to cite it. However, we have invested time and effort in creating RobotComponents, and we would appreciate if you would cite if you used. To cite RobotComponents in publications use:

```
EDEK Uni Kassel (2020).  
RobotComponents v0.09.000: Intuitive Robot Programming for ABB Robots inside of Rhinoceros Grasshopper. 
URL https://github.com/RobotComponents/RobotComponents
```

Note that there are two reasons for citing the software used. One is giving recognition to the work done by others which we already addressed. The other is giving details on the system used so that experiments can be replicated. For this, you should cite the version of RobotComponents used. See [How to cite and describe software](https://software.ac.uk/how-cite-software) for more details and an in depth discussion.

## Version numbering
RobotComponents uses the following version numbering scheme: 
```
0.xx.xxx ---> major release  
x.00.xxx ---> minor release (e.g. new functions, new components etc. )  
x.xx.000 ---> bug fixes and small improvements
```

## References
[Dawod M. et al. (2020) Continuous Timber Fibre Placement. In: Gengnagel C., Baverel O., Burry J., Ramsgaard Thomsen M., Weinzierl S. (eds) Impact: Design With All Senses. DMSB 2019. Springer, Cham](https://link.springer.com/chapter/10.1007/978-3-030-29829-6_36)

## License
Robot Components

Copyright (c) 2018-2020 [The Robot Components authors and / or their affiliations](AUTHORS.md)

Robot Components is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License version 3.0 as published by the Free Software Foundation. 

Robot Components is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with RobotComponents; If not, see <http://www.gnu.org/licenses/>.

@license GPL-3.0 <https://www.gnu.org/licenses/gpl.html>
