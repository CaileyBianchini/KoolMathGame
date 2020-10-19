using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        private Entity[] _entity;
        public bool Started { get; private set; }


        public Scene()
        {
            _entity = new Entity[0];
        }

        public void AddEntity(Entity entity)
        {
            //Creates new array with a size that is one greater than the old array
            Entity[] appendedArray = new Entity[_entity.Length + 1];
            //Copies values from old array to new array
            for(int i = 0; i < _entity.Length; i++)
            {
                appendedArray[i] = _entity[i];
            }
            //Set the class valure in the new array to be the entity we want to add
            appendedArray[_entity.Length] = entity;
            //Sets the old array to hold the values of the new array
            _entity = appendedArray;
        }

        public bool RemoveEntity(int index)
        {
            //checks to see if the index is outside of bounds of our array
            if(index < 0 || index >= _entity.Length)
            {
                return false;
            }

            bool entityRemoved = false;

            //creates a new array with one less than the old array
            Entity[] newArray = new Entity[_entity.Length - 1];
            //creates variable to accesss tempArray variable
            int j = 0;
            //copies variables from old array to the new array, minus the selected index
            for(int i = 0; i < _entity.Length; i++)
            {
                //in the current index is not the index that needs to be taken out,
                //it will then add the value into the old array and increament j
                if(i != index)
                {
                    newArray[j] = _entity[i];
                    j++;
                }
                else
                {
                    entityRemoved = true;
                }
            }
            //set the old array to be tempArray
            _entity = newArray;
            return entityRemoved;
        }

        public bool RemoveEntity(Entity entity)
        {
            //Check to see if the actor was null
            if(entity == null)
            {
                return false;
            }

            bool entityRemoved = false;

            Entity[] newArray = new Entity[_entity.Length - 1];

            int j = 0;

            for(int i = 0; i < _entity.Length; i++)
            {
                if(entity != _entity[i])
                {
                    newArray[j] = _entity[i];
                    j++;
                }
                else
                {
                    entityRemoved = true;
                    if (_entity[i].Started)
                        _entity[i].End();
                }
            }
            //Sets the old array to the new array
            _entity = newArray;
            //returns wether or not the ternimation was successful
            return entityRemoved;
        }
        
        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update()
        {
            for (int i = 0; i < _entity.Length; i++)
            {
                if (!_entity[i].Started)
                    _entity[i].Start();

                _entity[i].Update();
            }
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _entity.Length; i++)
            {
                _entity[i].Draw();
            }
        }

        public virtual void End()
        {
            for(int i = 0; i < _entity.Length; i++)
            {
                if (_entity[i].Started)
                    _entity[i].End();
            }
            Started = false;
        }
    }
}
