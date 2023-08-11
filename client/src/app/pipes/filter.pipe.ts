import { Pipe, PipeTransform } from '@angular/core';
import { Picture } from '../interfaces/picture';

@Pipe({
  name: 'filter',
})
export class FilterPipe implements PipeTransform {
  transform(items: Picture[], searchText: string): Picture[] {
    if (!items) return [];
    if (!searchText) return items;

    searchText = searchText.toLowerCase();

    return items.filter((item) => {
    
      const name = item.imageName.toLowerCase(); 
      const artist = item.artistName.toLowerCase(); 
      return name.includes(searchText) || artist.includes(searchText);
    });
  }
}
