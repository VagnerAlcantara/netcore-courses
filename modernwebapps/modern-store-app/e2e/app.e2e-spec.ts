import { ModernStoreAppPage } from './app.po';

describe('modern-store-app App', function() {
  let page: ModernStoreAppPage;

  beforeEach(() => {
    page = new ModernStoreAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
