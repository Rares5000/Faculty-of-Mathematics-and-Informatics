import Data.List

-- Intro

myInt = 31415926535897932384626433832795028841971693993751058209749445923
double :: Integer -> Integer
double x = x+x

triple :: Integer -> Integer
triple x = x+x+x

maxim :: Integer -> Integer -> Integer
maxim x y = if (x > y) then x else y

-- maxim3 x y z = maxim x (maxim y z)

-- maxim3 x y z = let u = (maxim x y) in (maxim u z)

{-maxim3 x y z =
let
u = maxim x y
in
maxim u z-}

maxim3 :: Integer -> Integer -> Integer -> Integer
maxim3 x y z =
    if (x >= y)
        then if (x >= z)
            then x
            else z
    else if (y >= z)
        then y
        else z

maxim4 :: Integer -> Integer -> Integer -> Integer -> Integer
maxim4 x y z k =
    let 
    u = maxim3 x y z
    in
    maxim u k

testmaxim4 :: Integer -> Integer -> Integer -> Integer -> Bool
testmaxim4 x y z k =
    let
    u = maxim4 x y z k
    in 
    if (u>=x && u>=y && u>=z && u>=k)
        then True
        else False

-- Exercises
-- a).
squaresum :: Integer -> Integer -> Integer
squaresum x y = x*x + y*y

-- b).
parity :: Integer -> String
parity x = if (x `mod` 2==0)
                then "par"
                else "impar"

-- c).
fact :: Integer -> Integer
fact x = if (x==0)
            then 1
            else x * fact(x-1)

-- d).
verif :: Integer -> Integer -> Bool
verif x y = if (x > y*2)
                then True
                else False

-- e).
-- maximum in ghci