export class ParameterDefaultManager
{
    public _config!: any[];

    constructor(config: any)
    {
        this._config = config;
    }

    public createDefault(): any
    {
        return this.handleDefault({});
    }

    public handleDefault(model: any): any
    {
        if(!model)
            model = {};
        for (const c of this._config) {
            if(!model[c.property]) {
      
              if(c.type === "Int32")
                model[c.property] = 0;
      
              if(c.type === "Double")
                model[c.property] = 0;
      
              if(c.type === "Vector")
                model[c.property] = {x: 0, y: 0, z: 0};
              
              if(c.type === "Range")
                model[c.property] = {from: 0, to: 0};
              
              if(c.type === "Boolean")
                model[c.property] = false;
      
              if(c.type === "MultiSelect")
                model[c.property] = [];
              
              if(c.type === "Select")
                model[c.property] = 0;
              
              if(c.type === "ObjectList")
                model[c.property] = [{}, {}, {}];
              
              if(c.type === "Group")
              {
                  const manager = new ParameterDefaultManager(c.subData.properties);
                  model[c.property] = manager.handleDefault(model[c.property]);

              }
            }
          }
          return model;
    }
}