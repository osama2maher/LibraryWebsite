<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="LibraryWebsite.Help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     	<style >


 h1{color: #824D4D;}

h2{
list-style:inherit;
color: #196780;
font-size: 25px;
}

h3{font-size: 23.5px; color: #004C1A;}

h4{font-size: 27px;}

p{ color: black; font-size: 22px:;}

 	</style>


    <h1> <strong> Faculty of Engineering Library Help :</strong>  </h1>

<h4> <a href="#admin"> <li>Administrator </li></a> </h4>
<h4><a href="#user"> <li>User </li> </a></h4>
<div id="admin">
<br> <br> <br>
 <h3>  Admin FAQ : </h3>
 <p><a href="#library">   What does our Library do ?</a> </br>
<a href="#register">   Register in our Library ?</a> </br>
<a href="#borrow">Borrow books  ?</a> </br>
<a href="#search">Search for books ?</a> </br>
<a href="#return">Return books ?</a> </br>
<a href="#new">Add new books ?</a> </br>
<a href="#delete"> Delete books ?</a> </br>
<a href="#edit"> Edit your profile ?</a> </br>
<a href="#report">Library Reports ?</a> </br>
<a href="#account">Edit accounts ?</a> </br>
<a href="#ufaq">Do you have more FAQs? </a> </br> </p>
</br></br></br></br></br></br>
 

<div id="library">
<h2> <li> What does our Library do ? </li>
<p> *Faculty of Engineering Library is Made for both uers and admins to help them : </br> 
-Updating details of user accounts .</br>
- Check availabilty of books.</br>
-  Mange the process of borrowing books .</br>
- insertion and  monitoring  time of borrowing books .     </br></p>
</div>
</br> </br>
___________________________________________________________________
<div id="register">
   <h2> <li> Register in our Library ? </li></h2>
 <p> * If you want to register you will find Register button is the top of the right side from our website . </br>

* another way to Register is that you log in and you will find Register button right there too . </br>
 </p>
</div>
</br> </br> 
___________________________________________________________________
<div id="borrow">
<h2> <li> Borrow books  ?</li> </h2>

<p>*  You have to Log in to your Account then go to your Main Page .</br>
* Press on Borrow book</br> 
* Now Enter :</br>
- Book Catagory</br>
- Book Title </br>
- Borrow Date </br>
- Borrow Period </br>
- User Email </br>
- Your Password </br>
* Then enter Borrow button .</br> </p>
</div>

</br></br>
___________________________________________________________________
<div id="search">
	
	<h2><li> Search for books ? </li> </h2>
<p>* You have to Log in to your Account then go to your Main Page .</br>
* Press on Books Info and enter : </br> 
- Catagory </br>
- Book title </br>
</p>
</div>
</br></br>
___________________________________________________________________
<div id="edit">
<h2><li>  Edit your profile ? </li> </h2>
<p>* You have to Log in to your Account then go to your Main Page .</br>
* Press on Account Info then enter your :</br> 
- Email </br>
- First name </br>
- Last name </br>
- Phone </br>
- Passowrd </br>
- confirm Passowrd </br>
* Then enter Update button .</br>
</p>

</div>
</br></br>
___________________________________________________________________

<div id="return">
<h2> <li> Return books ? </li> </h2>
<p>*You have to Log in to your Account then go to your Main Page . </br>

* Press on Return Book the enter : </br>
- User Email </br>
- Book title </br>
* Then enter Return button </br>
</p>
</div>
</br></br>

___________________________________________________________________
<div id="new">

<h2><li> Add new books ?</li></h2> 

<p>* You have to Log in to your Account then go to your Main Page .</br>

* Press on Books info and then Add Book then enter  </br>
  Book Catagory or add new one if it wasn't available : </br>
- Book title </br>
- Book author </br>
* Then enter Add Book button .</br>
</p>
</div>
</br></br></br>

___________________________________________________________________
<div id="delete">
<h2><li> Delete books ? </li></h2>
<p>* You have to Log in to your Account then go to your Main Page .</br>
* Press On Books info The enter :</br>
- Catagory </br>
- Book Title </br>
* Then Press Delete Button </br> 
</p>
</div>
</br></br>
___________________________________________________________________
<div id="report">
	
<h2><li> Library Reports ?</li> </h2>
<p>* You have to Log in to your Account then go to your Main Page . </br>
* Press on Reports and then you will able to see : </br>
- Number of user accounts </br>
- Number of admin accounts </br> 
- Number of books </br>
- Number of book catagories </br>
- Number of Borrowed books </br>
- Number of currently borrowed books </br> 
- Number of returned books </br>
- Number of Fined Users </br>
- Plot for this Reports </br>
</p>
</div>
</br></br>

___________________________________________________________________
<div id="account">
<h2> <li> Edit accounts ? </h2>
<p>* You have to Log in to your Account then go to your Main Page .</br>
* Press on User Accounts Info the enter : </br>
- User Email </br>
* Then you will be able to : </br> 
- Delete User </br>
- Upgrade to Admin </br>
- Add new account </br>
</p>
</div>
</br></br>

</div>
</br> </br>
___________________________________________________________________

<div id="user">
<br> <br> <br>
 <h3>  User FAQ : </h3>
 <p><a href="#ulibrary">   what does our Library do ?</a> </br>
<a href="#uregister">   Register in our Library ?</a> </br>
<a href="#uborrow">Borrow books  ?</a> </br>
<a href="#uextend">Extend time of borrowing ? </a> </br>
<a href="#search">Search for books ?</a> </br>
<a href="#ureturn">Return books ?</a> </br>
<a href="#new">Add new books ?</a> </br>
<a href="#edit"> Edit your profile ?</a> </br>
<a href="#ufaq">Do you have more FAQs? </a> </br> </p>
</br></br></br></br></br></br>

___________________________________________________________________
<div id="ulibrary">
<h2> <li> what does our Library do ? </li></h2>
<p> *Faculty of Engineering Library is Made for both uers and admins to help them : </br> 
-Updating details of user accounts .</br>
- Check availabilty of books.</br>
-  Mange the process of borrowing books .</br>
- insertion and  monitoring  time of borrowing books .     </br></p>
</div>
</br> </br>
___________________________________________________________________
<div id="uregister">
   <h2> <li> Register in our Library ? </li></h2>
 <p> * If you want to register you will find Register button is the top of the right side    from our website . </br>

* another way to Register is that you log in and you will find Register button right there too . </br>

* if you are not able to Register online then you go to our place and we will register for you there . </br> </p>
</div>
</br> </br> 
___________________________________________________________________
<div id="uborrow">
<h2> <li> Borrow books  ?</li> </h2>

<p>*  * you have to come to our Place to borrow books but you can't borrow until you have an account </br> 
 * you can check availability of books from our website.</p>
</div>

</br></br>


___________________________________________________________________
<div id="ureturn">
<h2> <li> Return books ? </li> </h2>
<p>* you have to come to our Place to Return books .  </br>
* you have to Return it on time or you will be forbidden from borrowing from our library .
<br>
</p>
</div>
</br></br>


___________________________________________________________________
<div id="uextend">
<h2><li> * Extend time of borrowing ?
 </li></h2>
<p>* You have to Log in to your Account then go to your Main Page .</br>
* You have to Log in to your Account then go to your Main Page .<br>
* Press on Extend Borrow Period and enter :<br>
-  Book Title <br>
- Extend Period and it must be less than 3 days. <br>
* Then enter Extend button . <br>

</p>
</div>
</br></br>

___________________________________________________________________
<div id="ufaq">
<h2>	<li> Do you have more FAQs ?</li> </h2>
 
</asp:Content>
