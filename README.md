# Street Fighter VI Wishlist Website
A wishlist website for the upcoming (2022?:expressionless:) video game Street Fighter VI. <br/>
Update: It's coming in 2023, let's go. :scream:

<br>
<br>

<img width="1264" alt="SFVI_home_page" src="https://user-images.githubusercontent.com/28534915/170894330-c695daff-ca18-48c3-a6e1-dc569b552ab0.PNG">

<br>
<br>

<img width="1272" alt="SFVI_admin_page" src="https://user-images.githubusercontent.com/28534915/170894336-dc26a83a-b21c-496a-a9b7-6d369b9b313b.PNG">

<br>
<br>

<img width="1266" alt="SFVI_profile_page" src="https://user-images.githubusercontent.com/28534915/170894338-5cf106cb-3d9c-4672-9c01-130eb962e930.PNG">

<br>
<br>


## About the website
Tools I used to build the website: </br>
*Full-stack framework* : asp.net core Blazor server side. </br>
*Data-base* : MongoDB Atlas. <br/>
*Hosting* : Azure. <br />
*Authentication* : Azure AD B2C <br/>
*Other tools* : Bootstrap 4, etc. <br />
*Readme* : This website is a fully functional wishlist website that has 3 access priorities: tourist, member, admin. <br />
Please sign up or email me for admin access to fully explore the infrastructure of this website. :hear_no_evil: 

<br>
<br>

## What I learned 
### *About Blazor and asp.net core* : 
Since Blazor is relatively new compared to MVC and Razor page, it has some really handy<br/>
features for modern web development. What I really like about blazor is first the routing. It is very clear and straightforward. <br /> 
I also like how you can use razor components where you can inject classes at the top of the pape to simplify coding process. <br />
Having frontend code and c# code on the same page makes it easier for me to debug ( Of course you can put the c# code in another file to make it
look like the razor page infrastructure). MVC and razor page make you understand better about how asp.net core works, but when it comes to overall development
experience I like Blazor the best. Combining it with Azure AD B2C makes the whole development process faster and easier. </br >

### *About database*  : 
It is my first time using NoSQL database. I really like it even though I didn't take advantage of EF core's </br >
features like scaffolding and  migration. It feels more like using Dapper with SQL to me and I like Dapper a lot. The overall use </br >
of mongoDB is easier than using SQL. You dont have to worry about duplicated data as long as it's not too absurd. I think I'll use MongoDB more
from now on if I build something from scratch and not want to worry too much of it being rational or not.<br/>

## *About Auth* :
First time using a third-party authentication system. It is easier to configure than using the built-in authentication system </br >
(Even though the set up part on Azure is kinda messy). The coding part is especially easier than implementing JWT from scratch by myself. </br >
The only thing I think users wouldn't like about it is the system UI. It looks very Microsoft and not custom enough even though you can change </br >
the icon and background picture. But overall it's really handy if you build a project from scratch and want something easier and faster. </br >You dont have to worry too much about authorization and security as it is being handled by Microsoft.
<br>
<br>


## Epilogue
Learned a lot from building this website. Struggled for a while to deploy it online but eventually figured it out after three days. </br>
Compared to Razor Page and MVC I think I like Blazor the best because it's really fast and straightforward. </br> 
I also like Azure AD B2C, the downside is that it's not free after a year and it handles 50000 monthly with the free tier azure (more than enough </br>
for my website :rofl:). MongoDB is nice too as there is no more DBContext stuff all you need is a dependency injection using a mongoDB client.</br >
I did implement responsive design in this website but somehow the virtualize box is not working properly. Have to fix that later so for now just </br >
use the desktop version lol





<br/><a href="https://sf6wishlist.azurewebsites.net/" target="_blank">Go to the website</a> <br/>
*(Please open the website on your computer and give it 15 to 30 seconds to load the website and database as it is being hosted on <br>
free tier Azure and Atlas. Please sign up to leave your ideas about what you want in Street Fighter VI if you like the series. :blush: <br> 
The mobile version is still in development.)*
<br>
<br>

## Credit
Big shout out to **IAmTimCorey** for sharing his knowledge,  <a href= "https://www.youtube.com/user/IAmTimCorey">check out his Youtube channel</a>.




