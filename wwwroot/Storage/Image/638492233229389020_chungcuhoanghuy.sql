CREATE TABLE `role_users` (
  `id` bigint PRIMARY KEY,
  `user_id` bigint,
  `role_id` bigint,
  `created_at` timestamp,
  `updated_at` timestamp
);

CREATE TABLE `roles` (
  `id` bigint PRIMARY KEY,
  `name` varchar(255),
  `created_at` timestamp,
  `updated_at` timestamp
);

CREATE TABLE `users` (
  `id` bigint PRIMARY KEY,
  `full_name` varchar(255),
  `phone` varchar(255),
  `email` varchar(255),
  `password` varchar(255),
  `email_verified_at` timestamp,
  `address` varchar(255),
  `about` longtext,
  `status` varchar(255),
  `remember_token` varchar(255),
  `created_at` timestamp,
  `updated_at` timestamp,
  `token` varchar(255),
  `avt` varchar(255)
);

CREATE TABLE `apartments` (
  `id` bigint PRIMARY KEY,
  `name` varchar(255),
  `description` longtext,
  `status` varchar(255),
  `thumbnail` longtext,
  `address` varchar(255),
  `number_floor` int,
  `total_apartments` int,
  `total_area` double(8,2),
  `total_houses` int,
  `amenities` longtext,
  `parent_id` bigint,
  `created_by` bigint,
  `created_at` timestamp,
  `updated_at` timestamp
);

CREATE TABLE `houses` (
  `id` bigint PRIMARY KEY,
  `house_code` varchar(255),
  `thumbnail` longtext,
  `description` longtext,
  `amenities` longtext,
  `gallery` longtext,
  `floor` int,
  `total_bedrooms` int,
  `total_bathrooms` int,
  `price` decimal(15,0),
  `total_area` int,
  `apartment_id` bigint,
  `status` varchar(255),
  `type` varchar(255),
  `created_by` bigint,
  `created_at` timestamp,
  `updated_at` timestamp,
  `is_hot` tinyint,
  `is_feature` tinyint
);

CREATE TABLE `contracts` (
  `id` bigint PRIMARY KEY,
  `house_id` bigint,
  `duration` bigint,
  `status` varchar(255),
  `price` decimal(15,0),
  `user_id` bigint,
  `created_at` timestamp,
  `updated_at` timestamp,
  `notes` varchar(255),
  `is_cancel` tinyint,
  `reason` varchar(255)
);

CREATE TABLE `contract_information` (
  `id` bigint PRIMARY KEY,
  `number_person` int,
  `contract_id` bigint,
  `status` varchar(255),
  `user_id` bigint,
  `full_name` varchar(255),
  `created_at` timestamp,
  `updated_at` timestamp,
  `email` varchar(255),
  `phone` varchar(255),
  `number_id` varchar(255),
  `address` varchar(255)
);

CREATE TABLE `contract_durations` (
  `id` bigint PRIMARY KEY,
  `name` varchar(255),
  `status` varchar(255),
  `created_at` timestamp,
  `updated_at` timestamp
);

CREATE TABLE `contract_histories` (
  `id` bigint PRIMARY KEY,
  `contract_id` varchar(255),
  `content` varchar(255),
  `created_at` timestamp,
  `updated_at` timestamp
);

CREATE TABLE `rules` (
  `id` bigint PRIMARY KEY,
  `name` varchar(255),
  `status` varchar(255),
  `created_at` timestamp,
  `updated_at` timestamp
);

CREATE TABLE `contacts` (
  `id` bigint PRIMARY KEY,
  `name` varchar(255),
  `email` varchar(255),
  `subject` varchar(255),
  `message` longtext,
  `status` varchar(255),
  `created_by` bigint,
  `created_at` timestamp,
  `updated_at` timestamp
);

CREATE TABLE `events` (
  `id` bigint PRIMARY KEY,
  `title` varchar(255),
  `short_description` varchar(255),
  `description` varchar(255),
  `thumbnail` longtext,
  `status` varchar(255),
  `created_by` bigint,
  `created_at` timestamp,
  `updated_at` timestamp
);

CREATE TABLE `revenues` (
  `id` bigint PRIMARY KEY,
  `total` varchar(255),
  `day` varchar(255),
  `month` varchar(255),
  `year` longtext,
  `status` varchar(255),
  `contract_id` bigint,
  `created_at` timestamp,
  `updated_at` timestamp
);

ALTER TABLE `role_users` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `roles` ADD FOREIGN KEY (`id`) REFERENCES `role_users` (`role_id`);

ALTER TABLE `apartments` ADD FOREIGN KEY (`created_by`) REFERENCES `users` (`id`);

ALTER TABLE `houses` ADD FOREIGN KEY (`created_by`) REFERENCES `users` (`id`);

ALTER TABLE `apartments` ADD FOREIGN KEY (`id`) REFERENCES `houses` (`apartment_id`);

ALTER TABLE `contracts` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `contracts` ADD FOREIGN KEY (`house_id`) REFERENCES `houses` (`id`);

ALTER TABLE `contracts` ADD FOREIGN KEY (`duration`) REFERENCES `contract_durations` (`id`);

ALTER TABLE `contract_information` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `contract_information` ADD FOREIGN KEY (`contract_id`) REFERENCES `contracts` (`id`);

ALTER TABLE `contract_histories` ADD FOREIGN KEY (`contract_id`) REFERENCES `contracts` (`id`);

ALTER TABLE `contacts` ADD FOREIGN KEY (`created_by`) REFERENCES `users` (`id`);

ALTER TABLE `events` ADD FOREIGN KEY (`created_by`) REFERENCES `users` (`id`);

ALTER TABLE `revenues` ADD FOREIGN KEY (`contract_id`) REFERENCES `contracts` (`id`);
