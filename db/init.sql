CREATE TABLE IF NOT EXISTS public."Users" (
  "Id" SERIAL PRIMARY KEY,
  "Username" VARCHAR(100) NOT NULL,
  "Password" VARCHAR(100) NOT NULL
);

INSERT INTO public."Users" ("Username", "Password")
VALUES ('admin', 'password');
