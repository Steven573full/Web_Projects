<?php 
//session_start();

?>

<div class="top-bar animate-dropdown">
	<div class="container">
		<div class="header-top-inner">
			<div class="cnt-account">
				<ul class="list-unstyled">

<?php if(strlen($_SESSION['login']))
    {   ?>
				<li><a href="#"><i class="icon fa fa-user"></i>Bienvenido -<?php echo htmlentities($_SESSION['username']);?></a></li>
				<?php } ?>

					<li><a href="micuenta.php"><i class="icon fa fa-user"></i>Mi cuenta</a></li>
					<li><a href="micarrito.php"><i class="icon fa fa-shopping-cart"></i>Mi carrito</a></li>
					<?php if(strlen($_SESSION['login'])==0)
    {   ?>
<li><a href="login.php"><i class="icon fa fa-sign-in"></i>Login</a></li>
<?php }
else{ ?>
	
				<li><a href="logout.php"><i class="icon fa fa-sign-out"></i>Logout</a></li>
				<?php } ?>	
				</ul>
			</div>

<div class="cnt-block">
				<ul class="list-unstyled list-inline">
					<li class="dropdown dropdown-small">
				
						
					</li>

				
				</ul>
			</div>
			
			<div class="clearfix"></div>
		</div>
	</div>
</div>