-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Okt 05. 12:59
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `members`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `members`
--

CREATE TABLE `members` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL,
  `gender` enum('M','F') DEFAULT NULL,
  `birth_date` date NOT NULL,
  `banned` tinyint(1) NOT NULL DEFAULT 0,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `members`
--

INSERT INTO `members` (`id`, `name`, `gender`, `birth_date`, `banned`, `created_at`, `updated_at`) VALUES
(1, 'Hajdu Mátyás', 'M', '2007-02-12', 0, '2022-01-03 07:17:01', '2022-04-10 18:35:20'),
(2, 'Orsós Kornél PhD', 'M', '2006-05-19', 1, '2022-03-05 12:49:04', '2022-04-10 18:35:20'),
(3, 'id. Novák Szandra PhD', 'F', '1995-10-29', 0, '2022-03-18 08:12:05', '2022-04-10 18:35:20'),
(4, 'Török Géza PhD', 'M', '1997-04-04', 0, '2022-01-06 21:57:16', '2022-04-10 18:35:20'),
(5, 'id. Balla Gréta', 'F', '2006-02-18', 1, '2022-01-15 22:00:08', '2022-04-10 18:35:20'),
(6, 'Dr. Hegedüs Zoltán PhD', 'M', '1984-10-18', 0, '2022-03-24 17:02:29', '2022-04-10 18:35:20'),
(7, 'ifj. Balogh Endrené', NULL, '2007-01-04', 0, '2022-04-01 02:31:09', '2022-04-10 18:35:20'),
(8, 'Prof. Fehér Kevin PhD', NULL, '1992-05-12', 1, '2022-03-17 00:16:55', '2022-04-10 18:35:20'),
(9, 'id. Török Zsóka PhD', 'F', '1978-01-06', 0, '2022-03-09 15:15:21', '2022-04-10 18:35:20'),
(10, 'Szalai Mátyás PhD', 'M', '1988-11-07', 0, '2022-02-13 00:55:22', '2022-04-10 18:35:20'),
(11, 'Kiss Robert', NULL, '1992-10-23', 0, '2024-09-27 15:56:27', '2024-09-27 15:56:27'),
(12, 'Kiss Lajos', 'M', '1992-12-31', 0, '2024-09-27 15:58:04', '2024-09-27 15:58:04'),
(13, 'id. Török Éva PhD', 'F', '1999-01-09', 0, '2024-09-27 23:31:13', '2024-09-27 23:31:13'),
(14, 'Évi', 'F', '1999-01-09', 0, '2024-09-27 23:39:42', '2024-09-27 23:39:42'),
(17, 'Laci', NULL, '2024-09-30', 1, '2024-09-30 21:34:38', '2024-09-30 21:34:38');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `migrations`
--

CREATE TABLE `migrations` (
  `id` int(10) UNSIGNED NOT NULL,
  `migration` varchar(255) NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(1, '2024_09_27_131825_create_payments_table', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `payments`
--

CREATE TABLE `payments` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `members_id` bigint(20) UNSIGNED NOT NULL,
  `amount` int(11) NOT NULL,
  `paid_at` date NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `payments`
--

INSERT INTO `payments` (`id`, `members_id`, `amount`, `paid_at`, `created_at`, `updated_at`) VALUES
(16, 4, 5000, '2024-09-08', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(17, 4, 5000, '2024-09-02', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(18, 3, 5000, '2024-09-17', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(19, 7, 5000, '2024-09-24', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(20, 6, 5000, '2024-09-23', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(21, 3, 5000, '2024-09-08', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(22, 9, 5000, '2024-09-01', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(23, 1, 5000, '2024-09-16', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(24, 4, 5000, '2024-09-23', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(25, 3, 5000, '2024-09-09', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(26, 3, 5000, '2024-09-19', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(27, 6, 5000, '2024-09-04', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(28, 4, 5000, '2024-09-18', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(29, 9, 5000, '2024-09-19', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(30, 10, 5000, '2024-09-16', '2024-09-27 13:57:42', '2024-09-27 13:57:42'),
(31, 2, 5000, '2024-09-28', '2024-09-27 22:39:22', '2024-09-27 22:39:22'),
(32, 2, 5000, '2024-09-28', '2024-09-27 22:39:32', '2024-09-27 22:39:32'),
(33, 8, 5000, '2024-09-28', '2024-09-27 22:47:21', '2024-09-27 22:47:21'),
(39, 8, 5000, '2024-09-28', '2024-09-27 23:25:35', '2024-09-27 23:25:35'),
(40, 8, 5000, '2024-09-28', '2024-09-27 23:26:45', '2024-09-27 23:26:45'),
(41, 8, 5000, '2024-09-28', '2024-09-27 23:27:42', '2024-09-27 23:27:42'),
(42, 13, 5000, '2024-08-20', '2024-07-31 23:27:42', '2024-07-31 23:27:42'),
(43, 17, 5000, '2024-10-01', '2024-09-30 23:33:24', '2024-09-30 23:33:24'),
(44, 12, 5000, '2024-10-01', '2024-09-30 23:33:35', '2024-09-30 23:33:35'),
(45, 11, 5000, '2024-10-01', '2024-09-30 23:33:47', '2024-09-30 23:33:47'),
(46, 14, 5000, '2024-10-01', '2024-09-30 23:34:33', '2024-09-30 23:34:33');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `payments_members_id_foreign` (`members_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `members`
--
ALTER TABLE `members`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT a táblához `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `payments`
--
ALTER TABLE `payments`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `payments`
--
ALTER TABLE `payments`
  ADD CONSTRAINT `payments_members_id_foreign` FOREIGN KEY (`members_id`) REFERENCES `members` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
