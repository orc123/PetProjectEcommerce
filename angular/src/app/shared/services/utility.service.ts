import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
@Injectable()
export class UtilityService {
    private _router: Router;

    constructor(router: Router) {
        this._router = router;
    }

    isEmpty(input) {
        if (input == undefined || input == null || input == '') {
            return true;
        }
        return false;
    }

    convertDateTime(date: Date) {
        const formattedDate = new Date(date.toString());
        return formattedDate.toDateString();
    }

    navigate(path: string) {
        this._router.navigate([path]);
    }
    Unflattering = (arr: any[]): any[] => {
        let map = {};
        let roots: any[] = [];
        let node = {
            data: {
                Id: '',
                ParentId: ''
            },
            expanded: true,
            children: []
        };
        for (let index = 0; index < arr.length; index += 1) {
            map[arr[index].Id] = index; // initialize the map
            arr[index].data = this.getAllProperties(arr[index]); // initialize the data
            arr[index].children = []; // initialize the children
        }
        for (let i = 0; i < arr.length; i += 1) {
            node = arr[i];
            if (node.data.ParentId !== null && arr[map[node.data.ParentId]] != undefined) {
                arr[map[node.data.ParentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    }
    UnFlatForLeftMenu = (arr: any[]): any[] => {
        let map = {};
        let roots: any[] = [];
        for (let i = 0; i < arr.length; i += 1) {
            let node = arr[i];
            node.children = [];
            map[node.id] = i; // use map to look-up the parents
            if (node.parentId !== null) {
                delete node['children'];
                arr[map[node.parentId]].children.push(node);
            } else {
                roots.push(node);
            }

        }
        return roots;
    }

    MakeSeoTitle(input: string) {
        if (input == undefined || input == '') {
            return '';
        }
        //?????i ch??? hoa th??nh ch??? th?????ng
        let slug = input.toLowerCase();

        //?????i k?? t??? c?? d???u th??nh kh??ng d???u
        slug = slug.replace(/??|??|???|???|??|??|???|???|???|???|???|??|???|???|???|???|???/gi, 'a');
        slug = slug.replace(/??|??|???|???|???|??|???|???|???|???|???/gi, 'e');
        slug = slug.replace(/i|??|??|???|??|???/gi, 'i');
        slug = slug.replace(/??|??|???|??|???|??|???|???|???|???|???|??|???|???|???|???|???/gi, 'o');
        slug = slug.replace(/??|??|???|??|???|??|???|???|???|???|???/gi, 'u');
        slug = slug.replace(/??|???|???|???|???/gi, 'y');
        slug = slug.replace(/??/gi, 'd');
        //X??a c??c k?? t??? ?????t bi???t
        slug = slug.replace(/\`|\~|\!|\@|\#|\||\$|\%|\^|\&|\*|\(|\)|\+|\=|\,|\.|\/|\?|\>|\<|\'|\"|\:|\;|_/gi, '');
        //?????i kho???ng tr???ng th??nh k?? t??? g???ch ngang
        slug = slug.replace(/ /gi, "-");
        //?????i nhi???u k?? t??? g???ch ngang li??n ti???p th??nh 1 k?? t??? g???ch ngang
        //Ph??ng tr?????ng h???p ng?????i nh???p v??o qu?? nhi???u k?? t??? tr???ng
        slug = slug.replace(/\-\-\-\-\-/gi, '-');
        slug = slug.replace(/\-\-\-\-/gi, '-');
        slug = slug.replace(/\-\-\-/gi, '-');
        slug = slug.replace(/\-\-/gi, '-');
        //X??a c??c k?? t??? g???ch ngang ??? ?????u v?? cu???i
        slug = '@' + slug + '@';
        slug = slug.replace(/\@\-|\-\@|\@/gi, '');

        return slug;
    }
    getDateFormatyyyymmdd(x) {
        let y = x.getFullYear().toString();
        let m = (x.getMonth() + 1).toString();
        let d = x.getDate().toString();
        (d.length == 1) && (d = '0' + d);
        (m.length == 1) && (m = '0' + m);
        let yyyymmdd = y + m + d;
        return yyyymmdd;
    }

    getAllProperties = (obj: object) => {
        const data = {};

        for (const [key, val] of Object.entries(obj)) {
            if (obj.hasOwnProperty(key)) {
                if (typeof val !== 'object') {
                    data[key] = val;
                }
            }
        }
        return data;
    }
}
