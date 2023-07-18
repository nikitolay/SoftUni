function heroicInventory(input) {
  let result = [];
  for (let i = 0; i < input.length; i++) {
    let current = input[i].split(" / ");
    let [name, isacc, ...items] = current;
    items = items.join().split(", ");
    let hero = {
      name,
      level: Number(isacc),
      items,
    };
    result.push(hero);
  }
  return JSON.stringify(result);
}
console.log(
  heroicInventory([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara",
  ])
);
