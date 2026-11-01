SELECT * FROM public.items
ORDER BY id ASC 


SELECT
    name,
    (replace(replace(embedding::text, '[', '{'), ']', '}')::float[])[1:5] as first_dimensions
FROM items
LIMIT 1;

SELECT 
    name,
    embedding <=> (
        SELECT embedding FROM items WHERE name LIKE '%test%' LIMIT 1
    ) as distance
FROM items
ORDER BY distance
LIMIT 3;

WITH web_book AS (
        SELECT embedding FROM items WHERE name LIKE '%test%' LIMIT 1
)
SELECT
	item_data,
    embedding <-> (SELECT embedding FROM web_book) as similarity
FROM items
ORDER BY similarity
LIMIT 3;

WITH web_book AS (
    SELECT embedding
    FROM items
    WHERE name LIKE '%test%'
    LIMIT 1
)
SELECT
    item_data,
    embedding <=> (
        SELECT embedding FROM web_book
    ) AS distance,
    1 - (embedding <=> (
        SELECT embedding FROM web_book
    )) AS similarity
FROM items
ORDER BY distance ASC
LIMIT 3;

INSERT INTO public.items(
	id, name, item_data, embedding)
	VALUES (3, 'test3', 
	'"----"'::jsonb, 
	'[]'::vector);