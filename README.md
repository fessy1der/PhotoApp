# PhotoApp
The main architecture of this project is MVC. Entity Framework is the persistence framework used in this project to load objects and save objects to the database. The approach used for migrations was code first using SQL Server Server express from my Machine.

During the course of this project i was able to learn the following

1. The structure of an MVC project and how to set it up.

2. How to structure my domain classes (which is the M in MVC). for better unit testing and seperation of concern i made sure to seperate the domain classes from the main project so the data can be treated as a different project which is referenced in the main project.

3. After so many Trials and tutorials i was able to understand the concept of Dependency injections and i was able to set up a seperate project for my services.

4. I added the interface to the Data projects and used the service to implement it using LINQ.

5. I also learnt how to work with the ActionResults in the controller, using the view models and returning a view based on this.

6. The most challenging part of this project was hosting the images in Azure and ensuring that the images added and the images rendered in the views were all hosted in Azure. 
