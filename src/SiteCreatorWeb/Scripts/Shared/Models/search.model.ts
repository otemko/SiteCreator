import { SearchPage } from './searchPage.model'
import { SearchUser } from './searchUser.model'
import { SearchSite } from './searchSite.model'


export class SearchResult {
    searchSites: SearchSite[]
    searchPages: SearchPage[];
    searchUsers: SearchUser[];
}