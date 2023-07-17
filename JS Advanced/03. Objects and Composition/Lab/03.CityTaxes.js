function cityRecord(city, population, treasury) {
  let obj = {
    name: city,
    population,
    treasury,
    taxRate: 10,
    collectTaxes() {
      this.treasury += this.population * this.taxRate;
    },
    applyGrowth(percentage) {
      this.population += Math.floor((this.population * percentage) / 100);
    },
    applyRecession(percentage) {
      this.treasury -= Math.ceil((this.treasury * percentage) / 100);
    },
  };
  return obj;
}
