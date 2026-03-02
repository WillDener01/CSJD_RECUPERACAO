BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "jogador" (
	"name"	VARCHAR(20),
	"posX"	REAL,
	"posY"	REAL,
	"posZ"	REAL
);
INSERT INTO "jogador" VALUES ('inimigo3',0.0,0.0,0.0);
INSERT INTO "jogador" VALUES ('inimigo4',0.0,0.0,0.0);
COMMIT;
