-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 29, 2022 at 12:09 AM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `shopping`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `creationDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `updationDate` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `username`, `password`, `creationDate`, `updationDate`) VALUES
(1, 'admin', '46f94c8de14fb36680850768ff1b7f2a', '2017-01-24 16:21:18', '27-04-2022 01:40:19 AM');

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id` int(11) NOT NULL,
  `categoryName` varchar(255) DEFAULT NULL,
  `categoryDescription` longtext DEFAULT NULL,
  `creationDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `updationDate` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `categoryName`, `categoryDescription`, `creationDate`, `updationDate`) VALUES
(3, 'Componentes de PC', 'Componentes sueltos', '2017-01-24 19:17:37', '30-01-2017 12:22:24 AM'),
(4, 'Perifericos', 'Perifericos de PC', '2017-01-24 19:19:32', ''),
(5, 'Accesorios', 'Todo tipo de accesorios', '2017-01-24 19:19:54', ''),
(6, 'Laptops y computadoras', 'Laptop y computadoras armadas', '2017-02-20 19:18:52', '');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `id` int(11) NOT NULL,
  `userId` int(11) DEFAULT NULL,
  `productId` varchar(255) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `orderDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `paymentMethod` varchar(50) DEFAULT NULL,
  `orderStatus` varchar(55) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`id`, `userId`, `productId`, `quantity`, `orderDate`, `paymentMethod`, `orderStatus`) VALUES
(7, 4, '15', 1, '2022-04-27 15:59:49', 'efectivo', 'Enviado'),
(8, 4, '16', 1, '2022-04-27 16:01:29', 'Pago por internet', NULL),
(9, 4, '16', 1, '2022-04-27 16:02:17', 'Pago por internet', NULL),
(10, 4, '15', 1, '2022-04-28 20:32:24', 'Tarjeta de credito', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `ordertrackhistory`
--

CREATE TABLE `ordertrackhistory` (
  `id` int(11) NOT NULL,
  `orderId` int(11) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `remark` mediumtext DEFAULT NULL,
  `postingDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordertrackhistory`
--

INSERT INTO `ordertrackhistory` (`id`, `orderId`, `status`, `remark`, `postingDate`) VALUES
(1, 3, 'in Process', 'Order has been Shipped.', '2017-03-10 19:36:45'),
(2, 1, 'Delivered', 'Order Has been delivered', '2017-03-10 19:37:31'),
(3, 3, 'Delivered', 'Product delivered successfully', '2017-03-10 19:43:04'),
(4, 4, 'in Process', 'Product ready for Shipping', '2017-03-10 19:50:36'),
(5, 7, 'Enviado', 'Enviar test', '2022-04-28 22:05:11');

-- --------------------------------------------------------

--
-- Table structure for table `productreviews`
--

CREATE TABLE `productreviews` (
  `id` int(11) NOT NULL,
  `productId` int(11) DEFAULT NULL,
  `quality` int(11) DEFAULT NULL,
  `price` int(11) DEFAULT NULL,
  `value` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `summary` varchar(255) DEFAULT NULL,
  `review` longtext DEFAULT NULL,
  `reviewDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `category` int(11) NOT NULL,
  `subCategory` int(11) DEFAULT NULL,
  `productName` varchar(255) DEFAULT NULL,
  `productCompany` varchar(255) DEFAULT NULL,
  `productPrice` int(11) DEFAULT NULL,
  `productPriceBeforeDiscount` int(11) DEFAULT NULL,
  `productDescription` longtext DEFAULT NULL,
  `productImage1` varchar(255) DEFAULT NULL,
  `productImage2` varchar(255) DEFAULT NULL,
  `productImage3` varchar(255) DEFAULT NULL,
  `shippingCharge` int(11) DEFAULT NULL,
  `productAvailability` varchar(255) DEFAULT NULL,
  `postingDate` timestamp NULL DEFAULT current_timestamp(),
  `updationDate` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `category`, `subCategory`, `productName`, `productCompany`, `productPrice`, `productPriceBeforeDiscount`, `productDescription`, `productImage1`, `productImage2`, `productImage3`, `shippingCharge`, `productAvailability`, `postingDate`, `updationDate`) VALUES
(1, 4, 3, 'Monitor 24 ASUS ProArt', 'Asus', 206000, 0, '<div class=\"HoUsOy\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 0px 16px; font-size: 18px; white-space: nowrap; line-height: 1.4; color: rgb(33, 33, 33); font-family: Roboto, Arial, sans-serif;\">General</div><ul style=\"box-sizing: border-box; margin-bottom: 0px; margin-left: 0px; color: rgb(33, 33, 33); font-family: Roboto, Arial, sans-serif; font-size: 14px;\"><li class=\"_1KuY3T row\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 0px 16px; list-style: none; display: flex; flex-flow: row wrap; width: 731px;\"><div class=\"vmXPri col col-3-12\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 8px 0px 0px; width: 182.75px; display: inline-block; vertical-align: top; color: rgb(135, 135, 135);\">Tamaño de la pantalla:</div><ul class=\"_3dG3ix col col-9-12\" style=\"box-sizing: border-box; margin-left: 0px; width: 548.25px; display: inline-block; vertical-align: top; line-height: 1.4;\"><li class=\"sNqDog\" style=\"box-sizing: border-box; margin: 0px; padding: 0px; list-style: none;\">24 pulgadas</li></ul></li><li class=\"_1KuY3T row\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 0px 16px; list-style: none; display: flex; flex-flow: row wrap; width: 731px;\"><div class=\"vmXPri col col-3-12\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 8px 0px 0px; width: 182.75px; display: inline-block; vertical-align: top; color: rgb(135, 135, 135);\">Resolución</div><ul class=\"_3dG3ix col col-9-12\" style=\"box-sizing: border-box; margin-left: 0px; width: 548.25px; display: inline-block; vertical-align: top; line-height: 1.4;\"><li class=\"sNqDog\" style=\"box-sizing: border-box; margin: 0px; padding: 0px; list-style: none;\">FHD 1920 x 1080 IPS</li></ul></li><li class=\"_1KuY3T row\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 0px 16px; list-style: none; display: flex; flex-flow: row wrap; width: 731px;\"><div class=\"vmXPri col col-3-12\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 8px 0px 0px; width: 182.75px; display: inline-block; vertical-align: top; color: rgb(135, 135, 135);\">Tiempo de respuesta:</div><ul class=\"_3dG3ix col col-9-12\" style=\"box-sizing: border-box; margin-left: 0px; width: 548.25px; display: inline-block; vertical-align: top; line-height: 1.4;\"><li class=\"sNqDog\" style=\"box-sizing: border-box; margin: 0px; padding: 0px; list-style: none;\">5 ms</li></ul></li><li class=\"_1KuY3T row\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 0px 16px; list-style: none; display: flex; flex-flow: row wrap; width: 731px;\"><div class=\"vmXPri col col-3-12\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 8px 0px 0px; width: 182.75px; display: inline-block; vertical-align: top; color: rgb(135, 135, 135);\">Screen Type</div><ul class=\"_3dG3ix col col-9-12\" style=\"box-sizing: border-box; margin-left: 0px; width: 548.25px; display: inline-block; vertical-align: top; line-height: 1.4;\"><li class=\"sNqDog\" style=\"box-sizing: border-box; margin: 0px; padding: 0px; list-style: none;\">LED</li></ul></li><li class=\"_1KuY3T row\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 0px 16px; list-style: none; display: flex; flex-flow: row wrap; width: 731px;\"><div class=\"vmXPri col col-3-12\" style=\"box-sizing: border-box; margin: 0px; padding: 0px 8px 0px 0px; width: 182.75px; display: inline-block; vertical-align: top; color: rgb(135, 135, 135);\">Conectividad:</div><ul class=\"_3dG3ix col col-9-12\" style=\"box-sizing: border-box; margin-left: 0px; width: 548.25px; display: inline-block; vertical-align: top; line-height: 1.4;\"><li class=\"sNqDog\" style=\"box-sizing: border-box; margin: 0px; padding: 0px; list-style: none;\">HDMI / VGA / Display Port</li></ul></li></ul>', 'asus1.png', 'asus2.png', 'asus3.png', 3000, 'In Stock', '2022-04-27 02:15:40', ''),
(2, 4, 4, 'Mouse Razer USB Viper Ultimate con Charging Dock', 'Razer', 126000, 0, '<br><div><ol><li>Factor de forma: Verdadero-ambidiestro<br></li><li>Conectividad: Inalámbrico<br></li><li>Razer™ HyperSpeed Alámbrico – Cable Speedflex<br></li><liDuración de la batería: Hasta 70 Horas<br></li><li>Iluminación: RGB Razer Chroma™ RGB<br></li></ol></div>', 'razer1.jpg', 'razer2.jpg', 'razer3.jpg', 0, 'In Stock', NULL, ''),
(3, 4, NULL, 'Headset RAZER Blackshark V2 PRO Rainbow Six', 'Razer', 119000, 0, 'La descripción va aquí', 'razerheadset1.webp', 'razerheadset2.webp', 'razerheadset3.webp', 0, 'In Stock', '2022-04-28 02:58:45', NULL),
(15, 3, 8, 'Tarjeta madre Gigabyte B450M DS3H V2', 'Gigabyte', 60000, 75000, '<span style=\"color: rgb(33, 33, 33); font-family: Roboto, Arial, sans-serif; font-size: 18px;\">Tarjeta madre Gigabyte B450M DS3H V2</span><span style=\"color: rgb(33, 33, 33); font-family: Roboto, Arial, sans-serif; font-size: 18px;\">&nbsp;&nbsp;Admite AMD Ryzen ™ serie 5000 / 3.ª generación Ryzen ™ / 2.ª generación Ryzen ™ / 1.ª generación Ryzen ™ / 2.ª generación Ryzen ™ con gráficos Radeon ™ Vega / 1.ª generación Ryzen ™ con gráficos Radeon ™ Vega / Athlon ™ con procesadores gráficos Radeon ™ Vega\nDDR4 sin búfer no ECC de doble canal, 4 DIMM\nCaracterística Solución VRM digital con MOSFET de bajo RDS (activado))</span><br><div><ul><li>Puertos HDMI, DVI-D para múltiples pantallas\nPCIe Gen3 x4 M.2 ultrarrápido con compatibilidad con modo PCIe NVMe y SATA<br></li><li>Condensadores de audio de alta calidad y protector de ruido de audio con iluminación de trayectoria de seguimiento LED\nLAN para juegos 8118 exclusiva de GIGABYTE con gestión de ancho de banda<br></li><li>RGB Fusion admite tiras de LED RGB en 7 colores\nSmart Fan 5 cuenta con 5 sensores de temperatura y 2 cabezales de ventilador híbridos con FAN STOP Ltd<br></li><li>Centro de aplicaciones que incluye las utilidades EasyTune ™ y Cloud Station ™\nPreparado para CEC 2019, ahorre energía con un simple clic<br></li></ul></div>', '10001.png', '10002.png', '10003.png', 0, 'In Stock', '2022-04-27 22:23:06', ''),
(16, 3, 8, 'Tarjeta Madre ProArt X570-CREATOR WIFI', 'Asus', 345000, 400000, '<ul><li>Socket: AMD AM4\nModelo: ASUS PROART X570-CREATOR WIFI\nAura Sync</li></ul>', 'w692.png', 'fwebp.webp', 'fwebp2.webp', 0, 'In Stock', '2022-04-27 22:36:31', ''),
(17, 5, 9, 'Silla Gaming Cougar Armor Titan Pro Royal', 'Cougar', 289000, 0, '<span style=\"color: rgb(33, 33, 33); font-family: Roboto, Arial, sans-serif; font-size: 18px;\">Diseño: de patrón de cuadros de diamantes</span><span style=\"color: rgb(33, 33, 33); font-family: Roboto, Arial, sans-serif; font-size: 18px;\">&nbsp;&nbsp;Superficie: textura similar a la micro gamuza de cuero de PVC transpirable</span><br><div><ul><li>Espuma: moldeadora de alta densidad<br></li><li>Reposabrazos: 4D<br></li><li>Mecanismo de inclinación: avanzado<br></li><li>Base: Vortex Aluminio 5 Estrellas<br></li></ul></div>', 'silla1.png', 'silla2.png', 'silla3.png', 0, 'In Stock', NULL, ''),
(18, 5, 10, 'Lian Li  STRIMER PLUS 8 Pines Triple  RGB', 'Lian Li', 25000, 0, 'Extension 8 Pines RGB', 'ext1.jpg', 'ext2.jpg', 'ext3.jpg', 0, 'In Stock', NULL, ''),
(19, 6, 12, 'MSI PULSE GL66 11UDK - I7 11800H - 16GB -RTX 3050TI - SSD -144 HZ', 'MSI', 1055000, 0, 'Pantalla: 15 pulgadas – 1920 x 1080 - IPS -240hz', 'msi1.png', 'msi2.png', 'msi3.png', 45, 'In Stock', NULL, ''),
(20, 6, 12, 'Configuración PC Cosmos Z690', 'Varios', 4275000, 30000, '<span style=\"color: rgb(33, 33, 33); font-family: Roboto, Arial, sans-serif; font-size: 18px;\">Procesador: Intel Core i7 12700KF</span><br><div><ul><li>Tarjeta madre: ASUS ROG STRIX Z690-A Gaming Wifi D4<br></li><li>Memoria ram: 32 GB Corsair 2x16GB 3600 MHz<br></li><li>Almacenamiento: M.2 WD de 1TB + SSD Kingston 1.92 TB<br></li><li>Case:  Cooler Master Cosmos C700M<br></li></ul></div>', 'pc1.webp', 'pc2.png', 'pc3.jpg', 0, 'In Stock', NULL, '');

-- --------------------------------------------------------

--
-- Table structure for table `subcategory`
--

CREATE TABLE `subcategory` (
  `id` int(11) NOT NULL,
  `categoryid` int(11) DEFAULT NULL,
  `subcategory` varchar(255) DEFAULT NULL,
  `creationDate` timestamp NULL DEFAULT current_timestamp(),
  `updationDate` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `subcategory`
--

INSERT INTO `subcategory` (`id`, `categoryid`, `subcategory`, `creationDate`, `updationDate`) VALUES
(19, 4, 'Laptops', '2017-02-04 04:13:00', '');

-- --------------------------------------------------------

--
-- Table structure for table `userlog`
--

CREATE TABLE `userlog` (
  `id` int(11) NOT NULL,
  `userEmail` varchar(255) DEFAULT NULL,
  `userip` binary(16) DEFAULT NULL,
  `loginTime` timestamp NULL DEFAULT current_timestamp(),
  `logout` varchar(255) DEFAULT NULL,
  `status` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `userlog`
--

INSERT INTO `userlog` (`id`, `userEmail`, `userip`, `loginTime`, `logout`, `status`) VALUES
(24, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-27 15:59:03', NULL, 0),
(25, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-27 15:59:22', NULL, 1),
(26, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-27 19:18:51', NULL, 0),
(27, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-27 19:18:57', NULL, 1),
(28, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-28 03:12:05', '27-04-2022 09:13:47 PM', 1),
(29, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-28 18:59:37', NULL, 0),
(30, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-28 18:59:40', '28-04-2022 01:00:21 PM', 1),
(31, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-28 19:00:25', NULL, 1),
(32, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-28 19:02:31', NULL, 0),
(33, 'leovm97@hotmail.com', 0x3a3a3100000000000000000000000000, '2022-04-28 19:02:37', NULL, 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `contactno` bigint(11) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `shippingAddress` longtext DEFAULT NULL,
  `shippingState` varchar(255) DEFAULT NULL,
  `shippingCity` varchar(255) DEFAULT NULL,
  `shippingPincode` int(11) DEFAULT NULL,
  `billingAddress` longtext DEFAULT NULL,
  `billingState` varchar(255) DEFAULT NULL,
  `billingCity` varchar(255) DEFAULT NULL,
  `billingPincode` int(11) DEFAULT NULL,
  `regDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `updationDate` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `contactno`, `password`, `shippingAddress`, `shippingState`, `shippingCity`, `shippingPincode`, `billingAddress`, `billingState`, `billingCity`, `billingPincode`, `regDate`, `updationDate`) VALUES
(4, 'Leo', 'leovm97@hotmail.com', 123, '36f17c3939ac3e7b2fc9396fa8e953ea', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2022-04-27 15:59:14', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `wishlist`
--

CREATE TABLE `wishlist` (
  `id` int(11) NOT NULL,
  `userId` int(11) DEFAULT NULL,
  `productId` int(11) DEFAULT NULL,
  `postingDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `ordertrackhistory`
--
ALTER TABLE `ordertrackhistory`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `productreviews`
--
ALTER TABLE `productreviews`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `subcategory`
--
ALTER TABLE `subcategory`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `userlog`
--
ALTER TABLE `userlog`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `wishlist`
--
ALTER TABLE `wishlist`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `ordertrackhistory`
--
ALTER TABLE `ordertrackhistory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `productreviews`
--
ALTER TABLE `productreviews`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `subcategory`
--
ALTER TABLE `subcategory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `userlog`
--
ALTER TABLE `userlog`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `wishlist`
--
ALTER TABLE `wishlist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
