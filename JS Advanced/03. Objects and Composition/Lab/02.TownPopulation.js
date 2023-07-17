function townPopulation(input) {
  let towns = {};
  for (const el of input) {
    let [town, population] = el.split(" <-> ");
    if (!towns[town]) {
      towns[town] = 0;
    }
    towns[town] += Number(population);
  }
  for (const town in towns) {
    console.log(`${town} : ${towns[town]}`);
  }
}
townPopulation([
  "Sofia <-> 1200000",
  "Montana <-> 20000",
  "New York <-> 10000000",
  "Washington <-> 2345000",
  "Las Vegas <-> 1000000",
]);
